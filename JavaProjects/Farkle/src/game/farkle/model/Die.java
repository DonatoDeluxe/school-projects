package game.farkle.model;
import java.util.Random;

/**
 * Ein Würfel welcher gerollt werden kann und
 * kann "herausgenommen" werden.
 *  
 * @author Fornito Serafino
 */
public class Die {
	private int value;
	private int range;
	private boolean active = true;
	private Random random = new Random();
	
	
	/**
	 * Die Konstruktor
	 */
	public Die() {
		this.range = 6;
		this.roll();
	}
	
	/**
	 * Die Konstruktor
	 * 
	 * @param range Anzahl der maximal Augenzahl.
	 */
	public Die(int range) {
		this.range = range;
		this.roll();
	}
	
	/**
	 * @return Momentane Augenzahl
	 */
	public int getValue() {
		return value;
	}
	
	/**
	 * @param active Aktiviere oder deaktivieren des Würfels.
	 */
	public void setActive(boolean active) {
		this.active = active;
	}
	
	/**
	 * @return Zustand des Würfels.
	 */
	public boolean getActive() {
		return active;
	}
	
	/**
	 * Würfel wird gerollt.
	 */
	public void roll() {
		if(this.active) {
			value = random.nextInt(range) + 1;
		}
	}
}