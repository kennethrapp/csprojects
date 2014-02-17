#ifndef VALIDATE_STRING_H
#define VALIDATE_STRING_H
namespace validate{
	class string{
	public:
		static bool numeric(std::string);
		static bool alnum(std::string);
		static bool floatnum(std::string);
		static bool money(std::string);
		static bool regex(std::string, std::string);
		
	};
}
#endif