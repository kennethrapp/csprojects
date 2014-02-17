#include"Rapp_Final.h"
#include<sstream>
#include<ctime>
/* ITSE 2331 
	Personal Finance Database
	Kenneth Rapp

*/
using namespace std;

DBConnection DB("SERVER.NO.LONGER.EXISTS", "ITSE2331", "USER.NO.LONGER.EXISTS", "PASSWORD");

char USER_TABLE[9] = "RappUser";
char ACCOUNT_TABLE[12] = "RappAccount";
char TRANSACTION_TABLE[16] = "RappTransaction";

int ActiveAccountID = 1;
int ActiveUserID = 1;

TableDefinition AccountTableDefinition,UserTableDefinition,TransactionTableDefinition;

double GetUserInput(string, double);
int Menu(string*, string);
void ActivateConsoleMenu();
void AccountMenu();
void ProfileMenu();
void TransactionMenu();
void ReportMenu();
void HelpMenu();
void CreateNewAccount();
void CreateNewProfile();
void SelectActiveProfile();
void SelectActiveAccount();
void ViewProfiles();
void ViewAccounts();
void ViewTransactions();
void DeleteProfile();
void DeleteAccount();
void TransactAmount(bool);
void ViewReport();
void ViewReport(int);
void CreateInTable(TableDefinition, char*, char*);

int main(){
	
	// user table
	UserTableDefinition.push_back(FieldDefinition("UserID",   15, false,  true));
	UserTableDefinition.push_back(FieldDefinition("UserName", 15, false, false));
	UserTableDefinition.push_back(FieldDefinition("Address",  35, false, false));
	UserTableDefinition.push_back(FieldDefinition("City",     20, false, false));
	UserTableDefinition.push_back(FieldDefinition("State",     2, false, false));
	UserTableDefinition.push_back(FieldDefinition("ZipCode",   5, false, false));
	UserTableDefinition.push_back(FieldDefinition("Email",    25, false, false));
	UserTableDefinition.push_back(FieldDefinition("Phone",    15, false, false));

	// account table
	AccountTableDefinition.push_back(FieldDefinition("AcctID",   15, false,  true));
	AccountTableDefinition.push_back(FieldDefinition("AcctName", 35, false, false));
	AccountTableDefinition.push_back(FieldDefinition("Address",  35, false, false));
	AccountTableDefinition.push_back(FieldDefinition("City",     35, false, false));
	AccountTableDefinition.push_back(FieldDefinition("State",    35, false, false));
	AccountTableDefinition.push_back(FieldDefinition("ZipCode",  35, false, false));
	AccountTableDefinition.push_back(FieldDefinition("Phone",    35, false, false));

	// transaction table
	TransactionTableDefinition.push_back(FieldDefinition("TransNum",    15, false, true));
	TransactionTableDefinition.push_back(FieldDefinition("AcctID",      15, false, true));
	TransactionTableDefinition.push_back(FieldDefinition("UserID",      15, false, true));
	TransactionTableDefinition.push_back(FieldDefinition("TransDate",   15, false, true));
	TransactionTableDefinition.push_back(FieldDefinition("TransAmount", 15, true,  true));
	TransactionTableDefinition.push_back(FieldDefinition("Balance",     15, true,  true));

	system("cls");
	//TransactAddAmount();
	
	ActivateConsoleMenu();
	return 0;
}

// activate the console menu bar. 
void ActivateConsoleMenu(){
	ConsoleUI ConsoleMenuBar("Personal Finance Application 1.0", 23, 151, 129);
	ConsoleMenuBar.add(" Profile ",      &ProfileMenu);
	ConsoleMenuBar.add(" Accounts ",     &AccountMenu);
	ConsoleMenuBar.add(" Transactions ", &TransactionMenu);
	ConsoleMenuBar.add(" Reports ",      &ReportMenu);
	ConsoleMenuBar.add(" Help ",         &HelpMenu);
	ConsoleMenuBar.run();
};

// generate a text console menu and return a selected option
int Menu(string* sOptions, string sHeader){
	
	cout << sHeader << endl << endl;

	for(int i=0; i<=sizeof(sOptions); i++){
		cout << "[" << i << "] " << sOptions[i] << endl;
	}

	int opt = GetUserInput("Select an option", sizeof(sOptions));
	return opt;
}	

void ProfileMenu(){

	string MenuOptions[] = {
		"exit this menu",
		"create new profile",
		"view profiles",
		"select active profile",
		"delete a profile"
	};
	
	switch(Menu(MenuOptions, "Profile Menu")){
		case 0:  system("cls");			return;
		case 1:  CreateNewProfile();	break;
		case 2:  ViewProfiles();		break;
		case 3:  SelectActiveProfile(); break;
		case 4:  DeleteProfile();		break;
		default:						return;
	}
}

void AccountMenu(){

	string MenuOptions[] = {
		"exit this menu",
		"create new account",
		"view accounts",
		"select active account",
		"delete an account"
	};
	
	switch(Menu(MenuOptions, "Accounts Menu")){
		case 0:  system("cls");			return;
		case 1:  CreateNewAccount();	break;
		case 2:  ViewAccounts();		break;
		case 3:  SelectActiveAccount(); break;
		case 4:  DeleteAccount();		break;
		default:						return;
	}
}

// transact with the current active account and profile
void TransactionMenu(){
	
	if(ActiveAccountID < 1){
		cout << "No active account has been selected.";
		return;
	}

	if(ActiveUserID < 1){
		cout << "No active profile has been selected.";
		return;
	}

	stringstream AAID(""); // active account id
	stringstream AUID(""); // active user id

	AAID << ActiveAccountID;
	AUID << ActiveUserID;

	if(DB.FieldExists(USER_TABLE, "UserID", (char*)AUID.str().c_str()) == false){
		ActiveUserID = -1;
		cout << "User ID selected does not exist.";
		return;
	}
	else if(DB.FieldExists(ACCOUNT_TABLE, "AcctID", (char*)AAID.str().c_str()) == false){
		ActiveAccountID = -1;
		cout << "Account ID selected does not exist.";
		return;
	}

	string MenuOptions[] = {
		"exit this menu",
		"add money",
		"withdraw money",
		"view transactions"
	};

	switch(Menu(MenuOptions, "Transactions Menu")){
		case 0: return;
		case 1:  TransactAmount(true); break;
		case 2:  TransactAmount(false); break;
		case 3:  ViewTransactions(); break;
		default: return;
	}
}

void HelpMenu(){
	cout << "press <- (left arrow) or (right arrow) -> to navigate the menu." << endl;
	cout << "to select a menu item, press enter." << endl;
}

// add a transaction to the table.
void TransactAmount(bool isCredit){

	if(isCredit){
		cout << "Deposit" << endl;
	}
	else{
		cout << "Withdraw" << endl;
	}

	stringstream AAID(""); // active account id
	stringstream AUID(""); // active user id
	stringstream TNUM(""); // transaction number
	stringstream TAMT(""); // transaction amount
	stringstream DATE(""); // timestamp
	stringstream NBAL(""); // updated balance

	// create a new transaction id
	int TransNum = DB.GetMaxField(TRANSACTION_TABLE, "TransNum");
	int newTransNum = TransNum+1;

	// get the transaction amount
	double transAmt = GetUserInput("Enter Transaction Amount", INT_MAX);

	stringstream sM("");
	sM << transAmt;

	// validation. Minimal validation. Better than nothing.

	if(!validate::string::money(sM.str())){
		cout << "that does not appear to be a valid monetary amount.";
		return;
	}
	
	AAID << ActiveAccountID;
	AUID << ActiveUserID;

	if(!validate::string::numeric(AAID.str())){
		ActiveAccountID = -1;
		cout << "The account id is invalid. " << endl;
		return;
	}

	if(!validate::string::numeric(AUID.str())){
		ActiveUserID = -1;
		cout << "the user id is invalid. " << endl;
		return;
	}

	stringstream clause("");
	
	// this is terrible, but it works. 
	clause << " UserID = '" << ActiveUserID << "' and AcctID = '" << ActiveAccountID << "' ";
	
	double exSum = DB.GetSumField(TRANSACTION_TABLE, "TransAmount", (char*)clause.str().c_str());
	
	TNUM << newTransNum;
	
	DATE << time(0);

	if(isCredit){
		TAMT << transAmt;
		NBAL << (exSum+transAmt);
	}
	else{
		TAMT << "-" << transAmt;
		NBAL << (exSum-transAmt);
	}
	
	TableDataSet NewDataSet;
	NewDataSet.push_back(make_pair("AcctID",      AAID.str().c_str()));
	NewDataSet.push_back(make_pair("UserID",      AUID.str().c_str()));
	NewDataSet.push_back(make_pair("TransNum",    TNUM.str().c_str()));
	NewDataSet.push_back(make_pair("TransAmount", TAMT.str().c_str()));
	NewDataSet.push_back(make_pair("TransDate",   DATE.str().c_str()));
	NewDataSet.push_back(make_pair("Balance",     NBAL.str().c_str()));
	
	DB.Create(TRANSACTION_TABLE, NewDataSet);
	DB.ShowTable(TRANSACTION_TABLE, NewDataSet, 2); 
} 

void ReportMenu(){
	if(ActiveAccountID < 1){
		cout << "No active account has been selected.";
		return;
	}

	if(ActiveUserID < 1){
		cout << "No active profile has been selected.";
		return;
	}

	stringstream AAID(""); // active account id
	stringstream AUID(""); // active user id

	AAID << ActiveAccountID;
	AUID << ActiveUserID;

	if(DB.FieldExists(USER_TABLE, "UserID", (char*)AUID.str().c_str()) == false){
		ActiveUserID = -1;
		cout << "User ID selected does not exist.";
		return;
	}
	else if(DB.FieldExists(ACCOUNT_TABLE, "AcctID", (char*)AAID.str().c_str()) == false){
		ActiveAccountID = -1;
		cout << "Account ID selected does not exist.";
		return;
	}

	string MenuOptions[] = {
		"exit this menu",
		"view all",
		"view last 24 hours",
		"view last 7 days"
	};

	switch(Menu(MenuOptions, "Transactions Menu")){
		case 0: return;
		case 1:  ViewReport(); break;
		case 2:  ViewReport(86400); break;
		case 3:  ViewReport(604800); break;
		default: return;
	}
}

// create a profile
void CreateNewProfile(){
	CreateInTable(UserTableDefinition, USER_TABLE, "UserID");
}

// create an account
void CreateNewAccount(){
	CreateInTable(AccountTableDefinition, ACCOUNT_TABLE, "AcctID");
}

// delete an account
void DeleteAccount(){
	
	TableDataSet NewDataSet;
	
	stringstream is("");
	
	ViewAccounts();
	
	is << GetUserInput("Select an ID to delete", DB.GetMaxField(ACCOUNT_TABLE, "AcctID"));
	
	NewDataSet.push_back(make_pair("AcctID", is.str()));
	DB.Delete(ACCOUNT_TABLE, NewDataSet);
	
	// delete transactions matching this user and account id
	TableDataSet TransactionTableDataSet;
	stringstream AAID(""); // active account id
	stringstream AUID(""); // active user id

	AAID << ActiveAccountID;
	AUID << ActiveUserID;

	if(DB.FieldExists(USER_TABLE, "UserID", (char*)AUID.str().c_str()) == false){
		ActiveUserID = -1;
		cout << "User ID selected does not exist.";
		return;
	}
	else if(DB.FieldExists(ACCOUNT_TABLE, "AcctID", (char*)AAID.str().c_str()) == false){
		ActiveAccountID = -1;
		cout << "Account ID selected does not exist.";
		return;
	}
	
	TransactionTableDataSet.push_back(make_pair("AcctID", AAID.str().c_str()));
	TransactionTableDataSet.push_back(make_pair("UserID", AUID.str().c_str()));

	DB.Delete(TRANSACTION_TABLE, TransactionTableDataSet);

	ActiveAccountID = -1;
}

// delete a profile
void DeleteProfile(){
	TableDataSet NewDataSet;
	
	stringstream is("");
	ViewProfiles();
	
	is << GetUserInput("Select an ID to delete", DB.GetMaxField(USER_TABLE, "UserID"));
	
	if(!validate::string::numeric(is.str())){
		cout << "invalid id";
		return;
	}

	NewDataSet.push_back(make_pair("UserID", is.str().c_str()));
	
	DB.Delete(USER_TABLE, NewDataSet);
	
	ActiveUserID=-1;
}

// select the profile to be the active profile
void SelectActiveProfile(){
	ViewProfiles(); 
	int maxID = DB.GetMaxField(USER_TABLE, "UserID");
	int selID = GetUserInput("Select a profile ID", maxID);
	stringstream is("");
	is<<selID;
	if(!validate::string::numeric(is.str())){
		cout << "invalid id";
		return;
	}
	ActiveUserID=selID;
	cout << "Active profile selected.";
	return;
}

// select an account to be the active account
void SelectActiveAccount(){
	ViewAccounts();
	int maxID = DB.GetMaxField(ACCOUNT_TABLE, "AcctID");
	int selID = GetUserInput("Select an account ID", maxID);
	stringstream is("");
	is<<selID;
	if(!validate::string::numeric(is.str())){
		cout << "invalid id";
		return;
	}
	ActiveAccountID=selID;
	cout << "Active account selected.";
	return;
}

void ViewProfiles(){
	DB.ShowTable(USER_TABLE,  DB.GetColumnsForTable(USER_TABLE));
	cout << endl;
}

void ViewAccounts(){
	DB.ShowTable(ACCOUNT_TABLE,  DB.GetColumnsForTable(ACCOUNT_TABLE));
	cout << endl;
}

// view transactions for the current account id and user id
void ViewTransactions(){

	TableDataSet TransactionTableDataSet;
	stringstream AAID(""); // active account id
	stringstream AUID(""); // active user id

	AAID << ActiveAccountID;
	AUID << ActiveUserID;

	if(!validate::string::numeric(AAID.str())){
		cout << "invalid  account id";
		return;
	}

	if(!validate::string::numeric(AUID.str())){
		cout << "invalid user id";
		return;
	}

	if(DB.FieldExists(USER_TABLE, "UserID", (char*)AUID.str().c_str()) == false){
		ActiveUserID = -1;
		cout << "User ID selected does not exist.";
		return;
	}
	else if(DB.FieldExists(ACCOUNT_TABLE, "AcctID", (char*)AAID.str().c_str()) == false){
		ActiveAccountID = -1;
		cout << "Account ID selected does not exist.";
		return;
	}

	
	TransactionTableDataSet.push_back(make_pair("AcctID", AAID.str().c_str()));
	TransactionTableDataSet.push_back(make_pair("UserID", AUID.str().c_str()));

	DB.ShowTable(TRANSACTION_TABLE, TransactionTableDataSet, 2);
}

void ViewReport(){}

void ViewReport(int seconds){
	
	TableDataSet TransactionTableDataSet;
	
	stringstream AAID(""); // active account id
	stringstream AUID(""); // active user id
	stringstream  SECS("");

	AAID << ActiveAccountID;
	AUID << ActiveUserID;
	SECS << (time(0)-seconds);

	TransactionTableDataSet.push_back(make_pair("AcctID", AAID.str().c_str()));
	TransactionTableDataSet.push_back(make_pair("UserID", AUID.str().c_str()));
	TransactionTableDataSet.push_back(make_pair(" TransDate >", SECS.str().c_str())); 

	DB.ShowTable(TRANSACTION_TABLE, TransactionTableDataSet, 2);
}


// get user prompts for table fields and add a new row
// to a table, with an auto-incremented id. 
void CreateInTable(TableDefinition Def, char* Table, char* key){
	
	string name, val;
	
	DB.UseTableDefinition(Def);
	//cout << "key: " << key;

	TableRow Columns = DB.GetColumnsForTable(Table); // get all the columns
	TableDataSet NewDataSet;

	for(unsigned int i=0; i<Columns.size(); i++){

		if(Columns[i] == key){
		 
			 int maxID = DB.GetMaxField(Table, key);
			 int newID = maxID+1;

			 stringstream ID("");
			 ID << newID;

			 NewDataSet.push_back(make_pair(key, (char*)ID.str().c_str()));
		}
		else{

			cout << Columns[i] << ": ";
		
			getline(cin, val);
		
			FieldDefinition WorkingFieldDefinition = DB.GetFieldDefinition((char*)Columns[i].c_str());

			if((WorkingFieldDefinition.getLength() > 0) && (WorkingFieldDefinition.Validate((char*)val.c_str()))){
				NewDataSet.push_back(make_pair(Columns[i],val));
			}
			else{
				cout << "validation failed for the field " << WorkingFieldDefinition.getName();
				return;
			}
		}
	}

	DB.Create(Table, NewDataSet);
	DB.ShowTable(Table, NewDataSet);
	return;
}

double GetUserInput(string label, double size){
	std::string sInput = "";
	double iInput = 0;
	do{
		std::cout<< label << ": ";
		std::getline(std::cin, sInput);
		iInput = std::atof(sInput.c_str());
	}while(iInput > size);
	return iInput;
}