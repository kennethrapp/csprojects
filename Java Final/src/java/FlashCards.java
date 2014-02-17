import java.util.*;
import java.awt.GridLayout;
import java.awt.event.*;
import javax.swing.*;
import java.io.*;
class FlashCards {
	
	
	private final List<FlashCard> FlashCardSet = new ArrayList<FlashCard>();
	
	private static int currentScore = 0;
	
	public FlashCards(){}

	public List<FlashCard> GetAll(){
		return FlashCardSet;
	}

	public static void updateScore(){
		currentScore++;
	}

	public static int getScore(){
		return currentScore;
	}

	public int GetSize(){
		return FlashCardSet.size();
	}

	public int GetRandomIndex(){
		Random random = new Random();
		return random.nextInt(GetSize());
	}

	

	public void add(String sQ, String[] sO, int sA){
		FlashCard f = new FlashCard(sQ, sO, sA);
		FlashCardSet.add(f);
	}

	public FlashCard get(int i){
		return FlashCardSet.get(i);
	}

	public static class FlashCard  implements Serializable{

		private final String Question;
		private final String[] Options;
		private final int Answer;

		public FlashCard(String sQ, String[] sO, int sA){
			Question = sQ; 
			Options  = sO; 
			Answer   = sA;  
		}

		public boolean isAnswer(int i){
			return (Answer == i);
		}

		/* return a JPanel for this flash card with full functionality. */
		public JPanel GUI(){
			JPanel gui = new JPanel();
			gui.setLayout(new GridLayout(3, 0));
			
			/*
			gui.setTitle("Flash Card");
			gui.setSize(w, h);
			gui.setLocationRelativeTo(null);
			gui.setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE); */

			JTextArea message = new JTextArea(Question);
			message.setWrapStyleWord(true);
        	message.setLineWrap(true);
        	message.setEditable(false);
       		message.setFocusable(false);
        	message.setOpaque(false);

        	gui.add(message);

        	CharacterKeys OptionKeys = new CharacterKeys(Options);

        	JPanel OptionPanel = OptionKeys.SetLayout(1,1);

        	gui.add(OptionPanel);

        	List<JButton> Buttons = OptionKeys.GetButtons();
        	
        	for(JButton _button:Buttons){
				
				_button.addActionListener(new ActionListener(){
					@Override
					public void actionPerformed(ActionEvent e){
						
						String _key =((JButton) e.getSource()).getText();
						
						if((Options[Answer] == _key)){
							updateScore();
							JOptionPane.showMessageDialog(null,"Correct. Your score is currently "+getScore());
						}
						else{
							JOptionPane.showMessageDialog(null, "Incorrect. The correct answer was "+Options[Answer]);
						}						

					}
				});
			}

			return gui;
		}
	}

	

	
	public static <T> T[] ShuffleArray(T[] array){
	    
	    int index;
	    T temp;
	    
	    Random random = new Random();
	    
	    for (int i = array.length - 1; i > 0; i--){
	        index = random.nextInt(i + 1);
	        temp = array[index];
	        array[index] = array[i];
	        array[i] = temp;
	    }

	    return array;
	}
}