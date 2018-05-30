package game.farkle.model;

/**
 * Ansammlung an Würfeln mit denen man Spielt.
 * 
 * @author Fornito Serafino
 */
public class Dice {
	private int amount;
	private Die[] dice;
	
	/**
	 * Dice Konstruktor mit 6 Würfel als Standartanzahl.
	 */
	public Dice() {
		amount = 6;
		dice = new Die[amount];
		for(int i = 0; i < amount; i++) {
			dice[i] = new Die();
		}
	}
	
	/**
	 * Dice Konstruktor mit einstellbarer Würfelanzahl.
	 * 
	 * @param newAmount Anzahl der Würfel.
	 */
	public Dice(int newAmount) {
		amount = newAmount;
		dice = new Die[amount];
		for(int i = 0; i < amount; i++) {
			dice[i] = new Die();
		}
	}
	
	/**
	 * @return Alle Würfel.
	 */
	public Die[] getDice() {
		return dice;
	}
	
	/**
	 * @param index Welcher Würfel (Würfel ID).
	 * @return Gwählter Würfel.
	 */
	public Die getDie(int index) {
		return dice[index];
	}
	
	/**
	 * @return Alle Würfelwerte als Array.
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
	 * @return Gibt true zurück wenn der Würfel gebraucht wird.
	 * @return Gibt false zurück wenn der Würfel nicht gebraucht wird.
	 */
	public boolean checkActiveDie() {
		for(Die die : getDice()) {
			if(die.getActive())
				return true;
		}
		return false;
	}
	
	/**
	 * Alle Würfel werden wieder gebraucht.
	 */
	public void setAllActive() {
		for(Die die : getDice()) {
			if(!die.getActive())
				die.setActive(true);
		}
	}
	
	/**
	 * Alle Würfel werden gerollt.
	 */
	public void roll() {
		for(Die die : dice) {
			die.roll();
		}
	}
}