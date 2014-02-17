/* Java Final
Kenneth Rapp

- 3 tables within the single application (3)
- 5 calculations within the single application (5) (calculator - as many calculations as you want)
- must run (1)
- integrate tables and calculations (1)
- calculations must show correct answers (1) (calculator)
- functional menu (1) (yep)
- gui (1) (yep)
- loop (1) (yeo)
- create, read, append to file (1) (IODriver, calculator)
- submit (1)
- name (2)

*/

import java.util.*;
import java.io.*;
import java.awt.GridLayout;
import java.awt.CardLayout;
import java.awt.event.*;
import javax.swing.*;
import java.text.*;

public class Main{

	public static final DataIO InputOutputDriver = new DataIO();
	public static final FlashCards FC = new FlashCards();
	public static final GenerateRandomMathProblemsOrSomething RandomMathProblemGenerator = new GenerateRandomMathProblemsOrSomething();
	private static final EvaluateExpression ExpressionEvaluator = new EvaluateExpression();

	public static void main(String[] args){

		DateFormat dateFormat = new SimpleDateFormat("yyyy/MM/dd HH:mm:ss");
		Date date = new Date();

		final JFrame frame = new JFrame();
		final JPanel cardsPanel = new JPanel(new CardLayout());

		List<String> Problems = new ArrayList<String>();
		
		frame.setLayout(new GridLayout(3, 1, 0, 0));
		frame.setTitle("Flash Cards - Kenneth Rapp "+dateFormat.format(date));
		frame.setSize(400,200);
		frame.setLocationRelativeTo(null);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		int numProblems = 20;
		
		while(FC.GetSize() < numProblems){

			String p = RandomMathProblemGenerator.Generate();

			System.out.println(p);

			try{ 
				int a = ExpressionEvaluator.evaluateExpression(p);
				String answer = ""+a;

				String[] opts = {""+(a-RandomMathProblemGenerator.RandomNumber(10)+1), answer, ""+(a+RandomMathProblemGenerator.RandomNumber(10)+1)};

				FC.ShuffleArray(opts);

				for(int j=0; j<opts.length; j++){
					if(opts[j] == answer) FC.add(p, opts, j);
				}

			/* 	I don't know how to predict these randomly generated problems will 
				resolve to a divide by zero error so i'm just going to catch them
				and skip them when they do. */
			}catch(Exception ex){

			}	
		}

		
		for(int i=0; i<FC.GetSize(); i++){
			cardsPanel.add(FC.get(i).GUI());
		}

		frame.add(cardsPanel);

		// add function keys for the thing

		String[] funcOpts = {
			"Next",
			"Calculator",
			"Save"
		};

		CharacterKeys FunctionKeys = new CharacterKeys(funcOpts);

        JPanel FunctionPanel = FunctionKeys.SetLayout(1, 1);

        List<JButton> FunctionButtons =FunctionKeys.GetButtons();

		// ->
		FunctionButtons.get(0).addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e){
				CardLayout cl = (CardLayout)(cardsPanel.getLayout());
				cl.next(cardsPanel);
			}
		});

		// calculator
		FunctionButtons.get(1).addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e){
				JFrame Panel = new JFrame();
				Panel.setSize(450,200);
				
				ExpressionCalculator Calc = new ExpressionCalculator();
				
				JPanel CalcPanel = Calc.GUI();
				
				Panel.add(CalcPanel);
				Panel.setVisible(true);
			}
		});

		// save
		FunctionButtons.get(2).addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e){
				// can't save, not serializable
				InputOutputDriver.Output("FLASHCARDS.dat", FC.GetAll());
			}
		});

        frame.add(FunctionPanel);

		frame.setVisible(true);
	}
}