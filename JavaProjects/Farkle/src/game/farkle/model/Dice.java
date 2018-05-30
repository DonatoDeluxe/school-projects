package game.farkle.model;

/**
 * Ansammlung an W�rfeln mit denen man Spielt.
 * 
 * @author Fornito Serafino
 */
public class Dice {
	private int amount;
	private Die[] dice;
	
	/**
	 * Dice Konstruktor mit 6 W�rfel als Standartanzahl.
	 */
	public Dice() {
		amount = 6;
		dice = new Die[amount];
		for(int i = 0; i < amount; i++) {
			dice[i] = new Die();
		}
	}
	
	/**
	 * Dice Konstruktor mit einstellbarer W�rfelanzahl.
	 * 
	 * @param newAmount Anzahl der W�rfel.
	 */
	public Dice(int newAmount) {
		amount = newAmount;
		dice = new Die[amount];
		for(int i = 0; i < amount; i++) {
			dice[i] = new Die();
		}
	}
	
	/**
	 * @return Alle W�rfel.
	 */
	public Die[] getDice() {
		return dice;
	}
	
	/**
	 * @param index Welcher W�rfel (W�rfel ID).
	 * @return Gw�hlter W�rfel.
	 */
	public Die getDie(int index) {
		return dice[index];
	}
	
	/**
	 * @return Alle W�rfelwerte als Array.
	 */
	public int[] getValues() {
		int[] ret = new int[dice.length];
		
		int i = 0;
		for(Die die : dice) {
			ret[i++] = die.getValue();
		}
		
		return ret;
	}
	
	/**
	 * @return Gibt true zur�ck wenn der W�rfel gebraucht wird.
	 * @return Gibt false zur�ck wenn der W�rfel nicht gebraucht wird.
	 */
	public boolean checkActiveDie() {
		for(Die die : getDice()) {
			if(die.getActive())
				return true;
		}
		return false;
	}
	
	/**
	 * Alle W�rfel werden wieder gebraucht.
	 */
	public void setAllActive() {
		for(Die die : getDice()) {
			if(!die.getActive())
				die.setActive(true);
		}
	}
	
	/**
	 * Alle W�rfel werden gerollt.
	 */
	public void roll() {
		for(Die die : dice) {
			die.roll();
		}
	}
}