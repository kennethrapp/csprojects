import java.io.*;
import java.util.*;


/* 	serializable I/O class
	just reads objects from a data file and writes objects to a data file. 
	needs file testing and stuff. 
*/

class DataIO{
	
	ObjectInputStream IN;
	ObjectOutputStream OUT;

	public static void main(String[] args){

		String file = "output.dat";

		List<String> list = Arrays.asList("one", "two", "three", "four", "five");
		
		DataIO IO = new DataIO();
		
		try{ 
			if(IO.Output(file, list)){
				if(IO.Input(file)){
					System.out.print(IO.IN.readObject());
					IO.IN.close();
				}

			}
		}catch(IOException e){
			System.out.println("I/O Exception");
		}
		catch(ClassNotFoundException e){
			System.out.println("Class not found");
		}
	}


	// save object to file
	public Boolean Output(String file, Object object){
		
		try{ 
			OUT = new ObjectOutputStream(new FileOutputStream(file));
			OUT.writeObject(object);
			OUT.close();
			return true;
		}
		catch(FileNotFoundException ex){
			System.out.println("file not found.");
		}
		catch(IOException ex){
			System.out.println("I/O exception");
		}
		return false;
	}

	// save file as input stream
	public Boolean Input(String file){

		try{ 
			IN = new ObjectInputStream(new FileInputStream(file));
			return true;
		}
		catch(FileNotFoundException ex){
			System.out.println("file not found.");
		}
		catch(IOException ex){
			System.out.println("I/O exception");
		}

		return false;
	}

	



}