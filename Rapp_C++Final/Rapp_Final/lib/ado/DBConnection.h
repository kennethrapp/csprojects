#ifndef DB_CONNECTION_H
#define DB_CONNECTION_H

#include <iostream>
#include <string>
#include <iomanip>
#include <vector>
#include <sstream>
#include <Windows.h>

// Get access to the msado15 DLL file
#import "C:\Program Files\Common Files\System\ado\msado15.dll" \
	rename("EOF", "EndOfFile")

const int DB_CONNECTION_BUFFER_ERROR = 500; // maximum buffer size for an error 
const int DB_CONNECTION_BUFFER_CMD = 500; // maximum buffer size for a command
const int DB_CONNECTION_BUFFER_FIELD = 500; // maximum buffer size for a single field

typedef std::vector<std::string> TableRow; // table row

typedef std::vector<std::pair<std::string,std::string>> TableDataSet; // multiple table rows

// definition class to store data about a table field
class FieldDefinition{
private:
	char* Name;
	int   Length;
	bool  isNullable;
	bool  isInteger;
public:
	FieldDefinition(){
		
	}
	FieldDefinition(char* N, int L, bool isN, bool isI){
		Name= N;
		Length = L;
		isNullable = isN;
		isInteger = isI;
	}
	char* getName(){
		return Name;
	}
	int getLength(){
		return Length;
	}

	// validate field content against the field definition values
	// set when this class was instantiated. 
	bool Validate(char* Content){

		int size = strlen(Content);

		std::string ContentStr = std::string(Content);

		//std::cout << "content: " << ContentStr << " as " << getName();
		
		// false if content is longer than it has to be
		if(size > Length){
			std::cout << "Length error - length must be " << Length << " or less, it is " << size << std::endl;
			return false;
		}
		
		// false if non-nullable and content is null or empty

		if(isNullable == false){

			if(Content == NULL){
				std::cout << "Content cannot be null." << std::endl;
				return false;
			}

			if((size == 0) || std::string(Content).empty()){
				std::cout << "Content cannot be empty." << std::endl;
				return false;
			}
		}
		
		// false if it contains non-integer values and has to be an integer
		/* this doesn't seem to work properly. Probably because of null terminated values. */
		
		std::size_t NaN = ContentStr.find_first_not_of( "0123456789" );

		if (( isInteger == true) &&  (NaN != std::string::npos)){
			
			std::cout << "Integer content must not contain non-integral values." << std::endl;
			std::cout << " Non numeric character found in position " << NaN << " of (" << ContentStr.substr(NaN, std::string::npos) << ")" << std::endl;

			return false;
		}
		
		return true;
	}
};

typedef std::vector<FieldDefinition> TableDefinition; // group of table definitions

class DBConnection{

private:

	HRESULT hr;

	char ErrStr[ DB_CONNECTION_BUFFER_ERROR ];
	char CmdStr[ DB_CONNECTION_BUFFER_CMD ];

	ADODB::_ConnectionPtr DBConnect;
	ADODB::_RecordsetPtr Rec;

	_variant_t vtValue;

	TableDefinition Table_Definition;

public:

	void ErrorHandler(char* caller, _com_error e, char* DisplayErr);
	
	// connect with the connection string and separate arguments for
	// the server, username and password
	DBConnection(const char*, const char*, const char*);
	DBConnection(const char*, const char*, const char*, const char*);

	void Connect(const char*, const char*, const char*);
	
	void Run(char* caller); 
	
	void ShowTable(char*, TableRow);	// display a single table row
	void ShowTable(char*);				// display a table (all rows)
	void ShowTable(char*, TableDataSet);// display a table (specific columns)
	void ShowTable(char*, TableDataSet, int); // display with numeric precision
	void ShowTable(char*, TableRow, int); // display with numeric precision

	TableRow GetColumnsForTable(char*); // get the columns for a table

	int GetMaxField(char*, char*); // get the maximum value of a field
	float GetSumField(char*, char*, char*); // get the maximum value of a field

	void UseTableDefinition(TableDefinition); // use a table definition for data validation

	FieldDefinition GetFieldDefinition(char*); // get the definition of a field
	
	/* CRUD methods */

	void Create(char*, TableDataSet);
	void Update(char*, char*, TableDataSet, TableDataSet);
	void Delete(char*, TableDataSet);

	bool FieldExists(char*, char*, char*); // determine if a field exists
	
	~DBConnection();
};

#endif DB_CONNECTION_H