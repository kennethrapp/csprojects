#ifndef CONSOLE_UI_H
#define CONSOLE_UI_H
#include <windows.h>
#include <conio.h>
#include <stdio.h>
#include<vector>

#define BLACK 0
#define BLUE 1
#define GREEN 2
#define CYAN 3
#define RED 4
#define MAGENTA 5
#define BROWN 6
#define LIGHTGREY 7
#define DARKGREY 8
#define LIGHTBLUE 9
#define LIGHTGREEN 10
#define LIGHTCYAN 11
#define LIGHTRED 12
#define LIGHTMAGENTA 13
#define YELLOW 14
#define WHITE 15
#define BLINK 128

#define BUTTON_UP 72
#define BUTTON_DOWN 80
#define BUTTON_LEFT 75
#define BUTTON_RIGHT 77
#define BUTTON_ENTER 13


//http://stackoverflow.com/questions/2582161/c-function-pointer-as-parameter
// http://stackoverflow.com/questions/4295432/typedef-function-pointer
const int MENU_BUFFER = 15;
const int MENU_START_LINE = 1;

typedef void (*callback_function)(); // type for conciseness


class ConsoleUI{
private:
	HANDLE con_out;
	HANDLE con_in;
	unsigned int cursor_at;
	CONSOLE_SCREEN_BUFFER_INFO csbi;
	std::vector<std::pair<char*, callback_function>> Menu;
	int title_color;
	int menu_color_selected;
	int menu_color_normal;
	int console_width;
	int console_height;
	char* title;

public:
	ConsoleUI(char*, int, int, int);
	void add(char*, callback_function);
	void print(int, int, int);
	void gotoxy(int, int);
	void selectNext();
	void selectPrev();
	void runCallback();
	void run();
	void setColors(int, int, int);
	void paint();
	void clearLine();
	void clearScreen();
};

#endif CONSOLE_UI_H
