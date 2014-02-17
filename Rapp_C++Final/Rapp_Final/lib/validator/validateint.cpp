#include <iostream>
#include "validateint.h"
/* integer validation class.
all the methods are lowercase because since validation is used more often,
not having to hit the shift key saves a bit of time. Probably not
best practice though. */

// return if an integer is (inclusive) between min and max
bool validate::integer::among(int iVal, int iMin, int iMax){
	if((iVal >= iMin) && (iVal <= iMax)){
		return true;
	}
	return false;
}

// return if an integer is (exclusive) between min and max
bool validate::integer::between(int iVal, int iMin, int iMax){
	if((iVal > iMin) && (iVal < iMax)){
		return true;
	}
	return false;
}
