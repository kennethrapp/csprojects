import java.util.*;
import java.awt.GridLayout;
import java.awt.event.*;
import javax.swing.*;
import java.io.*;

class ExpressionCalculator{

	private static final EvaluateExpression ExpressionEvaluator = new EvaluateExpression();
	private static final DataIO InputOutputDriver = new DataIO();
	private final JTextField EntryField = new JTextField();
	private final CharacterKeys Keyboard = new CharacterKeys("1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "(" , ")", "+", "-", "/", "*", ".");
	private final CharacterKeys Actions = new CharacterKeys("Reset","Evaluate","Save","Recall");
	
	public JPanel GUI(){
		
		JPanel CalculatorPanel = new JPanel();
		
		CalculatorPanel.setLayout(new GridLayout(3, 1, 0, 0));

		JPanel KeyboardLayout = Keyboard.SetLayout(3, 3);
		
		List<JButton> Buttons = Keyboard.GetButtons();

		for(JButton _button:Buttons){
			_button.addActionListener(new ActionListener(){
				@Override
				public void actionPerformed(ActionEvent e){
					String _key =((JButton) e.getSource()).getText();
					String _cur = EntryField.getText();
					EntryField.setText(_cur+_key);
				}
			});
		}

		// action key layout
		JPanel AKLayout = Actions.SetLayout(1,1);
		List<JButton> ActionButtons = Actions.GetButtons();

		// reset
		ActionButtons.get(0).addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e){
				EntryField.setText("");
			}
		});

		

		//eval
		ActionButtons.get(1).addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e){
				String t = (EntryField).getText();
				if(t.length() > 0){ 
					int answer = ExpressionEvaluator.evaluateExpression(t);
					EntryField.setText(new Integer(answer).toString());
				}
			}
		});

		//save (saves to file)
		ActionButtons.get(2).addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e){
				String text = (EntryField).getText();
				InputOutputDriver.Output("RECALL.dat", text);
			}
		});

		// recall (reads from file)
		ActionButtons.get(3).addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e){
				try{ 
					if(InputOutputDriver.Input("RECALL.dat")){
						EntryField.setText((String)(InputOutputDriver.IN.readObject()));
						InputOutputDriver.IN.close();
					}
				}catch(IOException ex){
					System.out.println("I/O Exception");
				}
				catch(ClassNotFoundException ex){
					System.out.println("Class not found");
				}
			}
		});

		CalculatorPanel.add(EntryField);
		CalculatorPanel.add(KeyboardLayout);
		CalculatorPanel.add(AKLayout);

		return CalculatorPanel;

	}
}