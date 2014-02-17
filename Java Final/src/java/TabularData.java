import java.util.*;
import java.io.*;
import javax.swing.*;
/*
Kenneth Rapp
ITSE 2317 Midterm
16 October 2013
*/
public class TabularData{
	
	// storing everything as a simple list, with an int for column
	// size, instead of dealing with a 2d list of lists 

	private final List<String> Data = new ArrayList<String>();
	private final int colsize; // column size since we're justworking with 1d 
	private final String[] Headers; // table headers
	private int count = 0; // counter 

	// return the next object in the data list 

	public String Next(){
		
		String r = Data.get(count);
		
		count = (count+1 % Data.size());
		
		return r;
	}

	// return the implicit dimensions of the table (w, h)

	public int[] getTableDimensions(){
		
		int[] dim = new int[2];
		
		dim[1] = colsize;
		dim[0] = Data.size() / colsize;

		return dim;
	}

	/* pull delimited data from a text file, store it in the data list
	along with headers. */

	public TabularData(String filename, String[] Headers, String cd){
		
		this.Headers = Headers;
		this.colsize = Headers.length;
		try { 
			
			Scanner infile = new Scanner(new File(filename));
			infile.useDelimiter(cd);
			
			do{
				Data.add( infile.next() );
			}while(infile.hasNext());

		} catch (FileNotFoundException e) {
        	System.out.println("File not found.");    
        	e.printStackTrace();
    	}
	}

	// return a JPanel layout for a table 
	public JPanel GetGUITable(){

		// get the table dimensions
		int[] dim = getTableDimensions();

		Object[][] TableData = new Object[dim[0]][dim[1]];

		// populate the object with the table data
		for(int i=0; i<dim[0]; i++){
			for(int j=0; j<dim[1]; j++){
				TableData[i][j] = Next(); 
			}
		} 

		JPanel Panel = new JPanel();
		JTable Table = new JTable(TableData, Headers);
		
		// resize (works ok enough, but i didn't write it so whatever)
		Table.setAutoResizeMode(JTable.AUTO_RESIZE_OFF);
		TableColumnAdjuster tca = new TableColumnAdjuster(Table);
		tca.adjustColumns();
		
		Panel.add(new JScrollPane(Table));
		return Panel;

	}
}

