package game.farkle.model;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import game.farkle.control.MainWindowController;
import javafx.scene.control.Label;
import javafx.scene.control.ToggleButton;

/**
 * Die Spielelogik für das Spiel-Hauptfenster.
 * 
 * @author Fornito Serafino
 */
public class MainWindowLogic {
	private String startString = "-ROLL-"; //string length has to be 6!
	private boolean isNewRound = false; //Flag für neue Runde
	private boolean isFarkle = false; //Flag für Farkle
	
	private int amount = 6; //Anzahl Würfel die für dieses Spiel benötigt werden.
	private Dice dice = new Dice(amount); //generiere alle nötigen Würfel.
	
	private int roll = 0; //Wurf-Runden-Zähler dieser Runde. 
	private int round = 0; //Runden-Zähler
	private int totalRoll = 0; //Wurf Punkte Total
	private int totalRound = 0; //Runden Punkte Total
	private List<Integer> rollScores = new ArrayList<Integer>(amount); //Alle Wurf-Runden-Punkte
	private List<Integer> roundScores = new ArrayList<Integer>(10); //Alle Runden-Punkte
	
	public MainWindowController mainWinController; //verbindung zum Controller
	
	/**
	 * MainWindowLogic Konstruktor
	 * 
	 * @param mainWinController Der zu zuweisende Controller.
	 */
	public MainWindowLogic(MainWindowController mainWinController) {
		setMainWinController(mainWinController);
	}
	
	/**
	 * Setzt den zu verknüpfenden Controller.
	 * 
	 * @param mainWinController Zu verknüpfenden Controller
	 */
	public void setMainWinController(MainWindowController mainWinController) {
		this.mainWinController = mainWinController;
	}
	
	/**
	 * Gibt den Starttext für die Würfel zurück.
	 * 
	 * @return String
	 */
	public String getStartString() {
		return startString;
	}

	/**
	 * Setzt den Starttext für die Würfel zurück.
	 * 
	 * @param startString Starttext für die Würfel
	 */
	public void setStartString(String startString) {
		this.startString = startString;
	}
	
	/**
	 * Gibt die aktuelle Wurf-Runden-Zahl zurück.
	 * 
	 * @return int
	 */
	public int getRoll() {
		return roll;
	}

	/**
	 * Setzt die Wurf-Runden-Zahl.
	 * 
	 * @param roll Wurf-Runden-Zahl
	 */
	public void setRoll(int roll) {
		this.roll = roll;
	}

	/**
	 * Gibt die aktuelle Runden-Zahl zurück.
	 * 
	 * @return int
	 */
	public int getRound() {
		return round;
	}

	/**
	 * Setzt die Runden-Zahl.
	 * 
	 * @param round Runden-Zahl
	 */
	public void setRound(int round) {
		this.round = round;
	}
	
	/**
	 * Gibt das aktuelle Wurf-Punkte-Total zurück.
	 * 
	 * @return totalRoll
	 */
	public int getTotalRoll() {
		return totalRoll;
	}

	/**
	 * Setzt das aktuelle Wurf-Punkte-Total.
	 * 
	 * @param totalRoll aktuelle Wurf-Punkte-Total
	 */
	public void setTotalRoll(int totalRoll) {
		this.totalRoll = totalRoll;
	}

	/**
	 * Gibt das aktuelle Runden-Punkte-Total zurück.
	 * 
	 * @return int
	 */
	public int getTotalRound() {
		return totalRound;
	}

	/**
	 * Setzt das aktuelle Runden-Punkte-Total.
	 * 
	 * @param totalRound aktuelle Runden-Punkte-Total
	 */
	public void setTotalRound(int totalRound) {
		this.totalRound = totalRound;
	}
	
	/**
	 * Gibt das "neu Runde"-Flag zurück.
	 * 
	 * @return boolean
	 */
	public boolean getIsNewRound() {
		return isNewRound;
	}

	/**
	 * Setzt das "neu Runde"-Flag.
	 * 
	 * @param isNewRound "neu Runde"-Flag
	 */
	public void setIsNewRound(boolean isNewRound) {
		this.isNewRound = isNewRound;
	}
	
	/**
	 * Gibt das "Farkle"-Flag zurück.
	 * 
	 * @return boolean
	 */
	public boolean getIsFarkle() {
		return isFarkle;
	}

	/**
	 * Setzt das "Farkle"-Flag.
	 * 
	 * @param isFarkle "Farkle"-Flag
	 */
	public void setIsFarkle(boolean isFarkle) {
		this.isFarkle = isFarkle;
	}

	/**
	 * Gibt die Spiele Würfel zurück.
	 * 
	 * @return Dice
	 */
	public Dice getGameDice() {
		return dice;
	}

	/**
	 * Setzte die Spiele Würfel.
	 * 
	 * @param dice Spiele Würfel
	 */
	public void setGameDice(Dice dice) {
		this.dice = dice;
	}

	/**
	 * Gibt die Wurf-Punkte-Liste zurück.
	 * 
	 * @return List Wurf-Punkte-Liste
	 */
	public List<Integer> getRollScores() {
		return rollScores;
	}

	/**
	 * Setzt die Wurf-Punkte-Liste.
	 * 
	 * @param rollScores Wurf-Punkte-Liste
	 */
	public void setRollScores(List<Integer> rollScores) {
		this.rollScores = rollScores;
	}
	
	/**
	 * Gibt die Runde-Punkte-Liste zurück.
	 * 
	 * @return List Runde-Punkte-Liste
	 */
	public List<Integer> getRoundScores() {
		return roundScores;
	}
	
	/**
	 * Setzt die Runde-Punkte-Liste.
	 * 
	 * @param roundScores Runde-Punkte-Liste
	 */
	public void setRoundScores(List<Integer> roundScores) {
		this.roundScores = roundScores;
	}
	
	
	
	
	
	/**
	 * Berechnet die Punkte der ausgewählten Würfel.   
	 * 
	 * @return int
	 */
	public int calcRollScore() {
		Die die;
		int[] valueCounter = new int[6];
		
		int i = 0;
		for(ToggleButton dieButton : mainWinController.getDiceButtons()) {
			die = getGameDice().getDie(i);
			if(dieButton.isSelected() && die.getActive()) {
				valueCounter[die.getValue()-1]++;
			}
			i++;
		}
		
		int points = 0;
		if(Arrays.stream(valueCounter).sum() > 0) {
			int threesome = 0;
			int valueCount = 0;
			for(i = 1; i <= 6; i++) {
				valueCount = valueCounter[i-1];
				if(valueCount != 0) {
					if(valueCount % 3 == 0) {
						threesome = (valueCount / 3);
					} else {
						threesome = (int) (((double) (valueCount)) / 3);
						
						if(i == 1 || i == 5)
							points += ((valueCount % 3) * 10 * i);
						else
							return 0;
					}
					
					points += (threesome * 100 * i);
					
					if(i == 1)
						points *= 10;
				}
			}
		}
		return points;
	}
	
	/**
	 * Überprüft ob aktive Würfel eine gültige Würfelkombination hat oder nicht.
	 * 
	 * @return boolean
	 */
	public boolean checkFarkle() {
		int[] valueCounter = new int[6];
		
		for(Die die : getGameDice().getDice()) {
			if(die.getActive()) {
				int dieValue = die.getValue();
				if(dieValue == 1 || dieValue == 5  || ++valueCounter[dieValue-1] >= 3 ) {
					setIsFarkle(false);
					return false;
				}
			}
		}

		setIsFarkle(true);
		return true;
	}
	
	/**
	 * Initialisiert neue Runde.
	 */
	public void newRound() {
		for(ToggleButton dieButton : mainWinController.getDiceButtons()) {
			dieButton.setDisable(true);
		}
		
		for(Die die : getGameDice().getDice()) {
			die.setActive(true);
		}
		
		clearRollScores();
		setTotalRoll(0);
		mainWinController.getRollTotal().setText("0");
		
		setIsNewRound(true);
	}
	
	/**
	 * Stellt die Wurf-Punkte zurück auf Anfangswerte.
	 */
	public void clearRollScores() {
		for(Label score : mainWinController.getRollScores()) {
			score.setText("-");
		}
		getRollScores().clear();
		setRoll(0);
	}
	
	/**
	 * Schreibt die vorgegebenen Wurf-Punkte in die aktuelle Wurf-Runde.
	 * 
	 * @param points Wurf-Punkte
	 */
	public void writeRollScore(int points) {
		int roll = getRoll();
		int currentTotal = getTotalRoll() + points;
		
		if(roll <= 6) {
			getRollScores().add(roll, points);
			setTotalRoll(currentTotal);
			setRoll(roll + 1);
			updateRollList(roll, points, currentTotal);
		}
	}
	
	/**
	 * Schreibt die vorgegebenen Runde-Punkte in die aktuelle Runde.
	 * 
	 * @param points Runde-Punkte
	 * @param text Runde-Punkte oder Farkle
	 */
	public void writeRoundScore(int points, String text) {
		int round = getRound();
		int currentTotal = getTotalRound() + points;
		if(round <= 10) {
			mainWinController.getRoundScores().get(round).setText(text);
			getRoundScores().add(round, points);
			setTotalRound(currentTotal);
			mainWinController.getRoundTotal().setText(Integer.toString(currentTotal));
			setRound(round + 1);
		}
	}
	
	/**
	 * Aktualisiert die Würfel-ToggleButtons und überprüft 
	 * ob alle Würfel in dieser Runde aufgebraucht worden sind.
	 */
	public void updateDiceButtons() {
		int i = 0;
		for(ToggleButton dieButton : mainWinController.getDiceButtons()) {
			if(dieButton.isSelected()) {
				getGameDice().getDie(i).setActive(false);
				dieButton.setDisable(true);
//				dieButton.setSelected(false);
			}
			i++;
		}
		
		if(!getGameDice().checkActiveDie()) {
			getGameDice().setAllActive();
			clearRollScores();
		}
	}
	
	/**
	 * Aktualisiert die Wurf-Liste und setzt/deaktiviert
	 * dementsprechend die Buttons "Roll" und "Write Points".
	 * 
	 * @param roll Wurf-Runde
	 * @param points Wurf-Punkte
	 * @param currentTotal vorheriges Wurf-Punkte-Total
	 */
	public void updateRollList(int roll, int points, int currentTotal) {
		mainWinController.getRollScores().get(roll).setText(Integer.toString(points));
		mainWinController.getRollTotal().setText(Integer.toString(currentTotal));
		if(points > 0)
			mainWinController.getRollBtn().setDisable(false);
		else
			mainWinController.getRollBtn().setDisable(true);
		
		if(currentTotal >= 300)
			mainWinController.getWritePointsBtn().setDisable(false);
		else
			mainWinController.getWritePointsBtn().setDisable(true);
	}
}
