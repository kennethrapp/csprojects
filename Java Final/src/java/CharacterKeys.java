import java.util.*;
import java.awt.Container;
import java.awt.FlowLayout;
import java.awt.GridLayout;
import java.awt.event.*;
import javax.swing.*;

class CharacterKeys extends JPanel{

	private final List<JButton> Buttons = new ArrayList<JButton>();
	
	// populate a list of button objects, using string arguments
	// for the button labels. 
	
	public CharacterKeys(String... buttons){
		for(String b: buttons){
			JButton _button = new JButton( b );
			Buttons.add(new JButton( b ));
		}
	}

	
	// return a grid layout with the button list as... buttons
	public JPanel SetLayout (int cx, int cy) {
		JPanel layout = new JPanel();
		layout.setLayout(new GridLayout(cx, cy));
		for(JButton _button: Buttons){
			layout.add(_button);
		}
		return layout;
	}

	// return button list
	public List<JButton> GetButtons(){
		return Buttons;
	}

}
