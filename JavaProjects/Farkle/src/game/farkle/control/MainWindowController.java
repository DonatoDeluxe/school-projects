package game.farkle.control;

import java.util.ArrayList;
import java.util.List;

import game.farkle.model.Die;
import game.farkle.model.MainWindowLogic;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.ToggleButton;
import javafx.scene.layout.HBox;

/**
 * Controller für das Spiel-Hauptfenster
 * 
 * @author Fornito Serafino
 */
public class MainWindowController {

	// View
	@FXML private HBox diceHBox;
	
	@FXML private Label roll1;
	@FXML private Label roll2;
	@FXML private Label roll3;
	@FXML private Label roll4;
	@FXML private Label roll5;
	@FXML private Label roll6;
	@FXML private Label rollTotal;
	
	@FXML private Label round1;
	@FXML private Label round2;
	@FXML private Label round3;
	@FXML private Label round4;
	@FXML private Label round5;
	@FXML private Label round6;
	@FXML private Label round7;
	@FXML private Label round8;
	@FXML private Label round9;
	@FXML private Label round10;
	@FXML private Label total;
	
	@FXML private Label gameOver;
	
	private List<Label> rollScores = new ArrayList<Label>(6);
	private List<Label> roundScores = new ArrayList<Label>(10);
	
	// Button
	@FXML private Button newGameBtn;
	@FXML private Button rollBtn;
	@FXML private Button writePointsBtn;
	
	@FXML private ToggleButton die1;
	@FXML private ToggleButton die2;
	@FXML private ToggleButton die3;
	@FXML private ToggleButton die4;
	@FXML private ToggleButton die5;
	@FXML private ToggleButton die6;
	
	private List<ToggleButton> diceButtons = new ArrayList<ToggleButton>(6);

	private MainWindowLogic mainWinLogic = new MainWindowLogic(this);
	
	public void setMainWinLogic(MainWindowLogic mainWinLogic) {
		this.mainWinLogic = mainWinLogic;
	}
	
	/**
	 * Initialisierung der In-/Outputs
	 */
	public void initializeInOutput() {
		getDiceButtons().add(0, die1);
		getDiceButtons().add(1, die2);
		getDiceButtons().add(2, die3);
		getDiceButtons().add(3, die4);
		getDiceButtons().add(4, die5);
		getDiceButtons().add(5, die6);
		
		getRollScores().add(0, roll1);
		getRollScores().add(1, roll2);
		getRollScores().add(2, roll3);
		getRollScores().add(3, roll4);
		getRollScores().add(4, roll5);
		getRollScores().add(5, roll6);
		
		getRoundScores().add(0, round1);
		getRoundScores().add(1, round2);
		getRoundScores().add(2, round3);
		getRoundScores().add(3, round4);
		getRoundScores().add(4, round5);
		getRoundScores().add(5, round6);
		getRoundScores().add(6, round7);
		getRoundScores().add(7, round8);
		getRoundScores().add(8, round9);
		getRoundScores().add(9, round10);
	}
	
	/**
	 * @return Button
	 */
	public Button getNewGameBtn() {
		return newGameBtn;
	}
	
	/**
	 * @return Button
	 */
	public Button getRollBtn() {
		return rollBtn;
	}
	
	/**
	 * @return Button
	 */
	public Button getWritePointsBtn() {
		return writePointsBtn;
	}
	
	/**
	 * @return HBox
	 */
	public HBox getDiceHBox() {
		return diceHBox;
	}
	
	/**
	 * @return Label
	 */
	public Label getRollTotal() {
		return rollTotal;
	}
	
	/**
	 * @return Label
	 */
	public Label getRoundTotal() {
		return total;
	}
	
	/**
	 * @return Label
	 */
	public Label getGameOver() {
		return gameOver;
	}
	
	/**
	 * @return Würfel-ToggleButtons-Liste
	 */
	public List<ToggleButton> getDiceButtons() {
		return diceButtons;
	}

	/**
	 * @param diceButtons Würfel-ToggleButtons-Liste
	 */
	public void setDiceButtons(List<ToggleButton> diceButtons) {
		this.diceButtons = diceButtons;
	}

	/**
	 * @return Wurf-Punkte-Liste
	 */
	public List<Label> getRollScores() {
		return rollScores;
	}

	/**
	 * @param rollScores Wurf-Punkte-Liste
	 */
	public void setRollScores(List<Label> rollScores) {
		this.rollScores = rollScores;
	}
	
	/**
	 * @return Runden-Punkte-Liste
	 */
	public List<Label> getRoundScores() {
		return roundScores;
	}
	
	/**
	 * @param roundScores Runden-Punkte-Liste
	 */
	public void setRoundScores(List<Label> roundScores) {
		this.roundScores = roundScores;
	}
	
	/**
	 * "New Game"-Button listener
	 * 
	 * Neues Spiel initialisierung.
	 */
	@FXML
	public void newGame() {
		mainWinLogic.newRound();
		
		int i = 0;
		String diceText = mainWinLogic.getStartString();
		if(diceText.length() != 6)
			diceText = " ROLL ";
		for(ToggleButton dieButton : getDiceButtons()) {
			dieButton.setSelected(true);
			dieButton.setText(Character.toString(diceText.charAt(i++)));
		}
		
		for(Label gameRound : getRoundScores()) {
			gameRound.setText("-");
		}
		total.setText("0");
		mainWinLogic.setRound(0);
		mainWinLogic.setTotalRound(0);
		mainWinLogic.getRoundScores().clear();
		
		getRollBtn().setDisable(false);
		getWritePointsBtn().setDisable(true);
		getNewGameBtn().setDisable(true);
		getGameOver().setVisible(false);
		getDiceHBox().setVisible(true);
	}
	
	/**
	 * "Roll"-Button listener
	 * 
	 * Schreibt und speichert die Wurf-Punktzahl falls nicht gerade eine neue 
	 * Runde statt gefunden hat und Würfelt die noch aktiven Würfel neu.
	 */
	@FXML
	public void doRoll() {
		if(mainWinLogic.getIsNewRound()) {
			getNewGameBtn().setDisable(false);
			mainWinLogic.setIsNewRound(false);
			mainWinLogic.setRoll(0);
		} else {
			int points = mainWinLogic.calcRollScore();
			if(points > 0) {
				mainWinLogic.writeRollScore(points);
				mainWinLogic.updateDiceButtons();
			} else
				return;
		}
		mainWinLogic.getGameDice().roll();
		
		int i = 0;
		int value = 0;
		Die die;
		for(ToggleButton dieButton : getDiceButtons()) {
			die = mainWinLogic.getGameDice().getDie(i++);
			if(die.getActive()) {
				value = mainWinLogic.getGameDice().getDie(i-1).getValue();
				dieButton.setDisable(false);
				dieButton.setSelected(false);
				dieButton.setText(Integer.toString(value));
			}
		}
		getRollBtn().setDisable(true);
		
		if(mainWinLogic.checkFarkle()) {
			doWritePoints();
		}
	}
	
	/**
	 * Würfel-ToggleButton onClick listener
	 * 
	 * Brechnet die Wurf-Punkte und das Wurf-Punkte-Total 
	 * und aktualisiert diese im FrontEnd.
	 */
	@FXML
	public void dieClicked() {
		int points = mainWinLogic.calcRollScore();
		int currentTotal = mainWinLogic.getTotalRoll() + points;
		int roll = mainWinLogic.getRoll();
		
		mainWinLogic.updateRollList(roll, points, currentTotal);
	}
	
	/**
	 * "Write Points"-Button listener
	 * 
	 * Schreibt falls möglich das aktuelle Wurf-Total 
	 * in die momentane Runde-Punkt-Liste.
	 */
	@FXML
	public void doWritePoints() {
		int score = 0;
		String text = "Farkle";
		
		int points = mainWinLogic.calcRollScore();
		mainWinLogic.writeRollScore(points);
		
		if(!mainWinLogic.getIsFarkle()) {
			score = mainWinLogic.getTotalRoll();
			if(score < 300)
				return;
			text = Integer.toString(score);
		}
		
		mainWinLogic.writeRoundScore(score, text);
		
		getWritePointsBtn().setDisable(true);
		getRollBtn().setDisable(false);
		if(mainWinLogic.getRoundScores().size() >= 10) {
			getRollBtn().setDisable(true);
			getGameOver().setVisible(true);
			getDiceHBox().setVisible(false);
		}
		
		mainWinLogic.newRound();
	}
}
