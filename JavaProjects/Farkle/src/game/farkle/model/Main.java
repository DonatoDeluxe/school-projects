package game.farkle.model;
	
import java.io.IOException;

import game.farkle.control.MainWindowController;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.stage.Stage;
import javafx.scene.Scene;
import javafx.scene.layout.AnchorPane;

public class Main extends Application {
	private Stage primaryStage;
	
	@Override
	public void start(Stage primaryStage) {
		this.primaryStage = primaryStage;
		mainWindow();
	}
	
	public void mainWindow() {
		try {
			FXMLLoader loader = new FXMLLoader(getClass().getResource("/game/farkle/ui/MainWindow.fxml"));
			AnchorPane pane = loader.load();
			
			primaryStage.setMinHeight(800.00);
			primaryStage.setMinWidth(800.00);
			
			MainWindowController mainWindowController = loader.getController();
			mainWindowController.initializeInOutput();
			mainWindowController.newGame();
			
			Scene scene = new Scene(pane);
			
			primaryStage.setScene(scene);
			primaryStage.show();
			
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	
	public static void main(String[] args) {
		launch(args);
	}
}
