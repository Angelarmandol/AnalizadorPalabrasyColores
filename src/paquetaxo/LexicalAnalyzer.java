package paquetaxo;

import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JTextField;
import java.awt.BorderLayout;
import java.awt.Color;

import javax.print.attribute.AttributeSet;
import javax.swing.JButton;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;
import javax.swing.JTextPane;
import javax.swing.text.BadLocationException;
import javax.swing.text.SimpleAttributeSet;
import javax.swing.text.StyleConstants;
import javax.swing.text.StyleContext;

import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;
import javax.swing.JTextArea;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.util.Arrays;
import javax.swing.JToolBar;
import javax.swing.JMenuBar;
import javax.swing.JMenu;

public class LexicalAnalyzer {

	private JFrame frame;
	String changeColor;
	String inicio = "inicio%";
	int contadorMensaje = 0;
	String mensaje = "";
	boolean endMsg = false;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					LexicalAnalyzer window = new LexicalAnalyzer();
					window.frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the application.
	 */
	public LexicalAnalyzer() {
		initialize();
	}

	/**
	 * Initialize the contents of the frame.
	 */
	private void initialize() {
		frame = new JFrame();
		frame.setBounds(100, 100, 909, 426);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.getContentPane().setLayout(null);

		JTextPane textPane = new JTextPane();
		textPane.setEditable(false);
		textPane.setBounds(437, 58, 414, 307);
		frame.getContentPane().add(textPane);

		JTextPane textPane_1 = new JTextPane();
		textPane_1.addKeyListener(new KeyAdapter() {

			
			@Override
			public void keyPressed(KeyEvent e) {}

			private void appendToPane(JTextPane tp, String msg, Color c) {
				StyleContext sc = StyleContext.getDefaultStyleContext();
				javax.swing.text.AttributeSet aset = sc.addAttribute(SimpleAttributeSet.EMPTY,
						StyleConstants.Foreground, c);

				aset = sc.addAttribute(aset, StyleConstants.FontFamily, "Lucida Console");
				aset = sc.addAttribute(aset, StyleConstants.Alignment, StyleConstants.ALIGN_JUSTIFIED);

				int len = tp.getDocument().getLength();

				tp.setCaretPosition(len);
				tp.setCharacterAttributes(aset, false);
				tp.replaceSelection(msg);

			}

		});
		textPane_1.setBounds(23, 56, 387, 307);
		frame.getContentPane().add(textPane_1);
		
		JMenuBar menuBar = new JMenuBar();
		menuBar.setBounds(0, 0, 893, 21);
		frame.getContentPane().add(menuBar);
		
		JMenu mnNewMenu = new JMenu("New menu");
		menuBar.add(mnNewMenu);
	}
}
