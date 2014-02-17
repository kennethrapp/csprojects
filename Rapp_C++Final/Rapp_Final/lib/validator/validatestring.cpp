#include <iostream>
#include <regex>
#include "validatestring.h"
// string validation class

// match a string by regex (wrapper for all the other methods)
bool validate::string::regex(std::string sInput, std::string sRegex){
	return std::regex_match(sInput, std::regex(sRegex));
}

// returns if a string contains only numeric values
bool validate::string::numeric(std::string sInput){
	return regex(sInput, "^[0-9]+$");
}

// string is a float (numbers, an optional dot, more optional numbers)
bool validate::string::floatnum(std::string sInput){
	return regex(sInput, "^[0-9]+.?[0-9]*$");
}

// string is monetary (numbers, an optional dot, two optional numbers.)
// no attempt being made to parse out monetary units, commas or
// capture the actual float from any of that. 
bool validate::string::money(std::string sInput){
	return regex(sInput, "^[0-9]+.?[0-9]{0,2}?$");
}
