package day2_1;

import java.io.*;
import java.util.*;

public class Main {
	
	public static boolean validGame(Hashtable<String, Integer> rules, String[] games) {
		for (String game : games) {
			for (String cubes : game.split(", ")) {
				cubes.replaceAll("\\s*","");
				String[] numColor = cubes.split(" ");
				if (rules.get(numColor[1]) < Integer.parseInt(numColor[0])) {
					return false;
				}
			}
		}
		return true;
	}
	
	public static void main(String [] args) {
		try {
			BufferedReader reader = new BufferedReader(new FileReader("list_of_games.txt"));
			Hashtable<String, Integer> maximumCubes = new Hashtable<>();
			maximumCubes.put("red", 12);
			maximumCubes.put("blue", 14);
			maximumCubes.put("green", 13);
			String line;
			int sumGames = 0;
			while((line = reader.readLine()) != null) {
				String [] splitedStr = line.split(": ");
				int gameNum = Integer.parseInt(splitedStr[0].replace("Game ", ""));
				System.out.print(gameNum);
				if (validGame(maximumCubes, splitedStr[1].split("; "))) {
					sumGames += gameNum;
					System.out.print(" Valid game");
				}
				System.out.print("\n");
			}
			reader.close();
			System.out.print("Sum of Games: " + sumGames);
		}
		catch (FileNotFoundException e) {
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
}
