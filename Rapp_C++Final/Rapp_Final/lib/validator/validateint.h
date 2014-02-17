#ifndef VALIDATE_INT_H
#define VALIDATE_INT_H
namespace validate{
	class integer{
	public:
		static bool between(int, int, int);
		static bool among(int, int, int);
	};
}
#endif