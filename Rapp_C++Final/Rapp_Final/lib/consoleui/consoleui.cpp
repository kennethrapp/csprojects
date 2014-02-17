#include"consoleui.h"
#include<iostream>
#include<iomanip>

ConsoleUI::ConsoleUI(char* title, int title_color, int menu_color_normal, int menu_color_selected){

	if(GetConsoleScreenBufferInfo(GetStdHandle(STD_OUTPUT_HANDLE), &csbi)){
		
		this->con_out = GetStdHandle(STD_OUTPUT_HANDLE);
		this->con_in = GetStdHandle(STD_INPUT_HANDLE);
		
		this->cursor_at = 0;
		this->title_color = title_color;
		this->menu_color_normal = menu_color_normal;
		this->menu_color_selected = menu_color_selected;
		
		this->console_width = csbi.srWindow.Right-csbi.srWindow.Left+1;
		this->console_height = csbi.srWindow.Top+csbi.srWindow.Bottom;
		
		this->title = title;
	}

}

// clears characters from the current line
void ConsoleUI::clearLine(){
	
	int cx =  this->csbi.dwCursorPosition.X;
	int cy =  this->csbi.dwCursorPosition.Y;

	for(int i=0; i< (this->console_width-cx); i++){
		std::cout << " ";
	}

	this->gotoxy(cx, cy);
}


void ConsoleUI::clearScreen(){

	this->gotoxy(0,2);

	//int cx =  this->csbi.dwCursorPosition.X;
	//int cy =  this->csbi.dwCursorPosition.Y;
	//this->gotoxy(cx, MENU_START_LINE+1);
	int w = this->console_width;

	for(int i=0; i<this->console_height-2; i++){
		for(int i=0; i< w; i++){
			std::cout << " ";
		}
	}
	this->gotoxy(0,2);

	//this->gotoxy(cx,cy);


}

void ConsoleUI::setColors(int title_color, int menu_color_normal, int menu_color_selected){
	this->title_color = title_color;
	this->menu_color_normal = menu_color_normal;
	this->menu_color_selected = menu_color_selected;
}

// add an item to the menu
void ConsoleUI::add(char* text, callback_function func){
	
	char charBuffer[ MENU_BUFFER ];

	if(sprintf_s(charBuffer, MENU_BUFFER, "%s", text) > -1){
		this->Menu.push_back(std::make_pair(text, func));	
	}
}

// change the cursor position
void ConsoleUI::gotoxy(int x, int y){
	COORD Coord;
	Coord.X=x;
	Coord.Y=y;
	SetConsoleCursorPosition(this->con_out, Coord);
}

// select the next item
void ConsoleUI::selectNext(){
	this->cursor_at = (++this->cursor_at % this->Menu.size());
}

// select the previous item
void ConsoleUI::selectPrev(){
	this->cursor_at = this->cursor_at == 0? this->Menu.size()-1: this->cursor_at -= 1;
}

// run the callback
void ConsoleUI::runCallback(){
	this->clearScreen();
	this->Menu[this->cursor_at].second();
	
}

// display the console, and runs the key listener
void ConsoleUI::run(){

	while(true){
		
		this->paint();

		switch( _getch() ){ // DO THE THING
			case BUTTON_RIGHT: this->selectNext(); break;
			case BUTTON_LEFT:  this->selectPrev(); break;
			case BUTTON_ENTER: this->runCallback();break;
		};
	}
}

// paints the menu on the console
void ConsoleUI::paint(){
	
	int fmw=0, iw = 0;

	this->gotoxy(0,0);
	
	// title line
	SetConsoleTextAttribute(this->con_out, this->title_color);

	std::cout << std::left << std::setw(this->console_width) << this->title;

	// menu line
	for(unsigned int i=0; i<this->Menu.size(); i++){

		// item width and total width for padding later
		iw = strlen(this->Menu[i].first);
		fmw += iw;
		
		//this->gotoxy((iw*i), MENU_START_LINE);
		
		// if the cursor is at the selected item, use the selected item scheme.
		SetConsoleTextAttribute(
			this->con_out,
			(i == this->cursor_at)? this->menu_color_selected: this->menu_color_normal
		);

		// print it out 
		std::cout << this->Menu[i].first;
	}

	// now we fill in the rest of the horizontal space if there is any
	SetConsoleTextAttribute(this->con_out, this->title_color );
	std::cout << std::setw(this->console_width - fmw) << " ";
	
	// reset to defaults
	SetConsoleTextAttribute(this->con_out, BLACK |	WHITE );
	std::cout << std::endl;
	

}