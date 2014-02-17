import java.util.*;

// generates random math problems or something.

class GenerateRandomMathProblemsOrSomething{

	public static void main(String[] args){
		System.out.println(Generate());
	}

	public static int RandomNumber(int r){
		Random random = new Random();
		int i = random.nextInt(r-1)+1;

		//System.out.println(i);

		return i;
	}

	public static char RandomOperator(){

		/* these will sometimes divide by zero. I have no idea how to
		predict that. */
		String operators = "+-*/";
		char[] c = operators.toCharArray();
		int rand = RandomNumber(operators.length()) % operators.length();

		return c[rand];
	}

	public static String Generate(){

		String s = "";
		int r = RandomNumber(3)+1;
		boolean isClosure=false;
		boolean isOperator=false;
		for(int i=0; i<r; i++){
			int closure = RandomNumber(10);
			if(s.length() > 0 && (closure % 2 == 0)){
				if(isOperator == false){ 
					isOperator=true;
					s += RandomOperator();
				}
				s += "(";
					isClosure=true;
			}
			s += RandomNumber(100);
			s += " " + RandomOperator() + " ";
			s += RandomNumber(100);
			if(isClosure == true){
				s += ")";
				if(i < r-1) s += RandomOperator();
				isClosure=false;
			}
		}

		return s;
	}
}