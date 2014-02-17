#include"DBConnection.h"
#include<fstream>
#include<vector>
#include<string>
#include<sstream>

void DBConnection::Connect(const char* Connection, const char* Username, const char* Password){
	
	::CoInitialize(NULL);
	
	this->DBConnect = NULL;
	this->Rec = NULL;
	
	try{
		
		// Prepare connection to the server
		this->hr = this->DBConnect.CreateInstance( __uuidof(ADODB::Connection ));
		this->DBConnect->CursorLocation = ADODB::adUseClient;
		
		// Opens the connection to the SQL Server database specified in the following parameters:
		this->DBConnect->Open(Connection, Username, Password, NULL);
	
	}catch(_com_error &e)
	{
		// Handler for any connection errors
		this->ErrorHandler(__FUNCTION__, e, this->ErrStr);
	}
}

DBConnection::DBConnection(const char* Connection, const char* Username, const char* Password){
	this->Connect(Connection, Username, Password);
}


DBConnection::DBConnection(const char* Server, const char* Database, const char* Username, const char* Password){
	// Provider=SQLOLEDB;Server=%s;Database=%s

	char connbuffer  [ DB_CONNECTION_BUFFER_CMD ]; // connection string character buffer
	char unamebuffer [ DB_CONNECTION_BUFFER_FIELD ];  // username character buffer
	char pwbuffer    [ DB_CONNECTION_BUFFER_FIELD ];  // password character buffer

	sprintf_s(connbuffer, DB_CONNECTION_BUFFER_CMD , "Provider=SQLOLEDB;Server=%s;Database=%s", Server, Database);
	sprintf_s(unamebuffer, DB_CONNECTION_BUFFER_FIELD, "%s", Username);
	sprintf_s(pwbuffer, DB_CONNECTION_BUFFER_FIELD, "%s", Password);
	
	std::cout << std::endl << "[connecting]" << std::endl;
	std::cout << "to " << connbuffer << std::endl;
	std::cout << "as " << unamebuffer << ", ******** " << std::endl;
	
	// test characterset for [A-z0-9-_.]
	this->Connect(connbuffer, unamebuffer, pwbuffer);

	// confirm connection?
	//http://www.w3schools.com/ado/prop_comm_state.asp
	
	std::cout << "Connection state is... ";
	
	switch(this->DBConnect->State){
		case 0:	std::cout << "closed"; break;
		case 1: std::cout << "open"; break;
		case 2: std::cout << "connecting"; break;
		case 4: std::cout << "executing"; break;
		case 8: std::cout << "fetching"; break; 
		default: std::cout << "this is the end, my only friend the end, of our elaborate plans, the end."; break;
	};
	
	std::cout << std::endl;
}

DBConnection::~DBConnection(){
	 ::CoUninitialize();
}

void DBConnection::UseTableDefinition(TableDefinition Def){
	Table_Definition = Def;
}

void DBConnection::ErrorHandler(char* caller, _com_error e, char* DisplayErr)
{
	std::cout << std::endl << "[ERROR]";

	// Gather error information	
	sprintf_s(DisplayErr, DB_CONNECTION_BUFFER_ERROR, "\nProgram Error:\n");
	sprintf_s(DisplayErr, DB_CONNECTION_BUFFER_ERROR, "\nFrom: %s\n", caller);
	sprintf_s(DisplayErr, DB_CONNECTION_BUFFER_ERROR, "%sCode Message: %s\n", DisplayErr, (char *)e.ErrorMessage());
	sprintf_s(DisplayErr, DB_CONNECTION_BUFFER_ERROR, "%sError Source: %s\n", DisplayErr, (char *)e.Source());
	sprintf_s(DisplayErr, DB_CONNECTION_BUFFER_ERROR, "%sError Description: %s\n\n", DisplayErr, (char *) e.Description());

	std::ofstream log;
	log.open("log.txt");

	log << DisplayErr << "\n";

	log.close();
	printf(this->ErrStr);
	exit(1);
}

// display an entire table (certain columns)
void DBConnection::ShowTable(char*Table, TableRow fields){
	ShowTable(Table, fields, 0);
}

void DBConnection::ShowTable(char *Table, TableRow fields, int precision){
	
	int fieldlen = fields.size();
	
	std::string name, val;
	std::stringstream qs(""); // query string
	std::stringstream os(""); // output string

	// iterate the fields and merge them with commas.

	for(int i=0; i<fieldlen; i++){
		qs << fields[i];
		if(i<(fieldlen-1)) qs << ",";
	}

	

	try{
		
		sprintf_s(this->CmdStr, DB_CONNECTION_BUFFER_CMD, "SELECT %s FROM %s", qs.str().c_str(), Table);
		this->Run(__FUNCTION__);
		
		if (!(this->Rec->EndOfFile)){
			
			for(int i=0; i<fieldlen; i++){
				os << std::left << std::setw(fields[i].size()+1) << fields[i];
			}

			os << std::endl << std::endl;

			// Data is found: goto first record
			this->Rec->MoveFirst();
			// While records exist, read each record
			while(!(this->Rec->EndOfFile)){

				for(int i=0; i<fieldlen; i++){
					
					variant_t fieldName;
					fieldName.SetString(fields[i].c_str());
					
					vtValue = Rec->Fields->GetItem(fieldName)->GetValue();
					val = (vtValue.vt == VT_NULL)?  "":  (char*) _bstr_t(vtValue);
					os << std::left << std::setw(fields[i].size()+1);
					os << std::setprecision(precision) << std::fixed << val;
					// if the string is 

				}

				os << std::endl;
				Rec->MoveNext();
			}
		}
	}catch(_com_error &e)
	{
		// Handler for any query error(s)
		this->ErrorHandler(__FUNCTION__, e, this->ErrStr);
	
	}

	std::cout << os.str();
}

// determine if a name/value pair match exists in the databse
bool DBConnection::FieldExists(char* Table, char* Field, char* Value){
	int i = 0;

	try{
		
		// find the largest current id
		sprintf_s(this->CmdStr, DB_CONNECTION_BUFFER_CMD, " SELECT COUNT(%s) AS COUNT_FIELD FROM %s WHERE %s = %s ", Field, Table, Field, Value);
		this->Run(__FUNCTION__);
		vtValue = Rec->Fields->GetItem("COUNT_FIELD")->GetValue();
		i = vtValue.intVal;
	
	}catch(_com_error &e){
		// Handler for any query error(s)
		this->ErrorHandler(__FUNCTION__, e, this->ErrStr);
	} 
	
	return (i > 0);
}

// show an entire table (all columns)
void DBConnection::ShowTable(char* Table){
	std::vector<std::string> Columns = this->GetColumnsForTable(Table);
	this->ShowTable(Table, Columns);
}

void DBConnection::ShowTable(char* Table, TableDataSet Rows){
	ShowTable(Table, Rows, 0);
}

// show a row from a table (all columns)
void DBConnection::ShowTable(char* Table, TableDataSet Rows, int precision){
	
	std::vector<std::string> fields = this->GetColumnsForTable(Table);
	
	std::stringstream qs(""); // name string
	std::stringstream ks(""); // key string
	std::stringstream os(""); // output string
	std::string val;
	
	int fieldlen = Rows.size();
	
	for(unsigned int i=0; i<fields.size(); i++){
		ks << fields[i];
		if(i<(fields.size()-1)) ks << ", ";
	}

	for(int i=0; i<fieldlen; i++){

		qs << "(" << Rows[i].first;
		
		// if the content is only digits, don't quote it.
		if ((Rows[i].second).find_first_not_of( "0123456789" ) == std::string::npos){
			qs << "="+Rows[i].second+") ";
		}
		else{
			qs << "='"+Rows[i].second+"') ";
		}
		
		unsigned int j = i;
		if(j < (Rows.size()-1)) qs << " AND ";
	}
	try{
		
		sprintf_s(this->CmdStr, DB_CONNECTION_BUFFER_CMD, "SELECT %s FROM %s WHERE  %s ", ks.str().c_str(), Table, qs.str().c_str());
		this->Run(__FUNCTION__);
		if (!(this->Rec->EndOfFile)){

			// Data is found: goto first record
			this->Rec->MoveFirst();
			// While records exist, read each record
			while(!(this->Rec->EndOfFile)){
				
				/* find out what the widest value for a field is */
				unsigned int fieldMaxWidth=0;
								
				for(unsigned int i=0; i < fields.size(); i++){
					if(fields[i].size() > fieldMaxWidth){
						fieldMaxWidth = fields[i].size();
					}
				}

				// display all the fields 
				for(unsigned int i=0; i < fields.size(); i++){

					variant_t fieldName;
					fieldName.SetString(fields[i].c_str());

					vtValue = Rec->Fields->GetItem(fieldName)->GetValue();
					
					val = (vtValue.vt == VT_NULL)?  "":  (char*) _bstr_t(vtValue);
					
					os << std::left << std::setw(fieldMaxWidth+1) << fields[i] << ": ";
					os << std::setprecision(precision) << std::fixed << val;
					os << std::endl;
				}

				os << std::endl;
				Rec->MoveNext();
			}
		}
	
	}catch(_com_error &e){
		// Handler for any query error(s)
		this->ErrorHandler(__FUNCTION__, e, this->ErrStr);
	}

	std::cout << os.str();
}

// find a definition for a field name 
FieldDefinition DBConnection::GetFieldDefinition(char* fieldName){

	for(unsigned int i=0; i<Table_Definition.size(); i++){
		std::stringstream fn("");
		std::stringstream fv("");
		
		fn << Table_Definition[i].getName();
		fv << fieldName;
		
		if(fn.str() == fv.str()){ 
			return Table_Definition[i];
		}
	}

	// returns a dummy definition if the field isn't found, because
	// we have to return a FieldDefinition type either way.
	FieldDefinition Dummy((char*)"" , -1, false, false);
	return Dummy;
}



// get the columns for a table
TableRow DBConnection::GetColumnsForTable(char* Table){	
	
	TableRow Columns;
	
	try{
		
		sprintf_s(this->CmdStr, DB_CONNECTION_BUFFER_CMD, "SELECT column_name FROM information_schema.columns where table_name = '%s' ", Table);
		this->Run(__FUNCTION__);
	
		if (!(this->Rec->EndOfFile)){
			
			std::string column;
		
			// Data is found: goto first record
			this->Rec->MoveFirst();
		
			// While records exist, read each record
			while(!(this->Rec->EndOfFile)){
				vtValue = Rec->Fields->GetItem("column_name")->GetValue();
				column = std::string((char*) _bstr_t(vtValue)); 				
				Columns.push_back(column);
				this->Rec->MoveNext();
			}
		}
	}catch(_com_error &e){
		// Handler for any query error(s)
		this->ErrorHandler(__FUNCTION__, e, this->ErrStr);
	} 

	return Columns;

}

// get the maximum value of a field 
int DBConnection::GetMaxField(char* Table, char* Field){
	try{
		
		// find the largest current id
		sprintf_s(this->CmdStr, DB_CONNECTION_BUFFER_CMD, "SELECT MAX(%s) AS MAX_FIELD FROM %s ", Field, Table);
		
		this->Run(__FUNCTION__);
		
		vtValue = Rec->Fields->GetItem("MAX_FIELD")->GetValue();
		
		return (vtValue.intVal);
	
	}catch(_com_error &e){
		// Handler for any query error(s)
		this->ErrorHandler(__FUNCTION__, e, this->ErrStr);
	} 
	
	return-1;
}

// get the sum value of a field. 
float DBConnection::GetSumField(char* Table, char* Field, char* Clause){
	try{

		float s = 0;
		
		/*  so even though vtValue below comes with a float value method, that appears to
			never return anything but 0, but getting it as a char and casting it works.
			I can see why no one actually does this in c++ anymore. */

		sprintf_s(this->CmdStr, DB_CONNECTION_BUFFER_CMD, "SELECT %s FROM %s where %s ", Field, Table, Clause);
		
		this->Run(__FUNCTION__);

		if (!(this->Rec->EndOfFile)){			
			this->Rec->MoveFirst();
			while(!(this->Rec->EndOfFile)){
				vtValue = Rec->Fields->GetItem(Field)->GetValue();
				float f = std::atof(_bstr_t(vtValue));
				s += f; // will work for + and - 
				this->Rec->MoveNext();
			}
		}
		
		return s;
	
	}catch(_com_error &e){
		// Handler for any query error(s)
		this->ErrorHandler(__FUNCTION__, e, this->ErrStr);
	} 
	
	return-1;
}

// show the command string then try to run it
void DBConnection::Run(char* caller){
try{
	// echo this for debugging
	//std::cout << std::endl << "[Executing]" << std::endl << this->CmdStr << std::endl << std::endl;
	
	this->Rec = this->DBConnect->Execute(this->CmdStr, NULL, 1);
}catch(_com_error &e){
		// Handler for any query error(s)
		this->ErrorHandler(caller, e, this->ErrStr);
	} 
}


void DBConnection::Create(char*Table, TableDataSet NewRow){
	try{
		// find the largest current id
		//int maxID = this->GetMaxField("Employee","EmployeeID");
		//int newID = maxID+1;

		std::stringstream ns(""); // name string
		std::stringstream vs(""); // value string
	
		for(unsigned int i=0; i<NewRow.size(); i++){

			ns << NewRow[i].first;
			vs << "'"+NewRow[i].second+"' ";
			
			if(i<(NewRow.size()-1)){
				ns << ",";
				vs << ",";
			}
		}

		sprintf_s(this->CmdStr, DB_CONNECTION_BUFFER_CMD, "INSERT INTO %s (%s) VALUES (%s)", Table, ns.str().c_str(), vs.str().c_str());
		this->Run(__FUNCTION__);

	}catch(_com_error &e){
		// Handler for any query error(s)
		this->ErrorHandler(__FUNCTION__, e, this->ErrStr);
		// Display query error(s)
		
	} 
}

void DBConnection::Update(char* Table, char* KeyField, TableDataSet KeyRow, TableDataSet NewRow){
	try{

		// find the largest current id
		int maxID = this->GetMaxField(Table, KeyField);
		int newID = maxID+1;

		std::stringstream ks(""); // key string
		std::stringstream vs(""); // value string
	
		for(unsigned int i=0; i<KeyRow.size(); i++){
			
			ks << KeyRow[i].first;
			ks << "='" << KeyRow[i].second<< "' ";
			
			if(i<(KeyRow.size()-1)){
				ks << " AND ";
			}
		}

		for(unsigned int i=0; i<NewRow.size(); i++){
			vs << NewRow[i].first << "='" << NewRow[i].second<< "'";
			if(i<(NewRow.size()-1)){
				vs << ",";
			}
		}

		sprintf_s(this->CmdStr, DB_CONNECTION_BUFFER_CMD, "UPDATE %s SET %s	WHERE %s", Table, vs.str().c_str(), ks.str().c_str());
		this->Run(__FUNCTION__);

	}catch(_com_error &e){
		// Handler for any query error(s)
		this->ErrorHandler(__FUNCTION__, e, this->ErrStr);
		// Display query error(s)
		
	} 
}

// delete entry or entries by multiple fields 
void DBConnection::Delete(char* Table, TableDataSet Fields){

	std::stringstream nvs(""); // name value string 
	
	for(unsigned int i=0; i<Fields.size(); i++){
		nvs << Fields[i].first;
		nvs <<  " = '" << Fields[i].second << "' ";
		
		if(i<(Fields.size()-1)){
			nvs << " AND ";
		}
	}
	
	sprintf_s(this->CmdStr, DB_CONNECTION_BUFFER_CMD, "DELETE FROM %s WHERE %s ",Table, nvs.str().c_str());
	this->Run(__FUNCTION__);
}
