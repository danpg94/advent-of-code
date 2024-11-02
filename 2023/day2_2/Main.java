package day2_2;

import java.io.*;
import java.util.*;

public class Main {
	@SuppressWarnings("serial")
	public static void main(String[] args) {
		try {
			BufferedReader reader = new BufferedReader(new FileReader("list_of_games.txt"));
			HashMap<String ,Integer> numCubesMap;
			String line;
			int sumPowTotal = 0;
			while((line = reader.readLine()) != null) {
				String[] splitedStr = line.split(": ");
				String[] games = splitedStr[1].split("; ");
				int gamePowSum = 1; 
				numCubesMap = new HashMap<String, Integer>(){{put("red", 0);put("blue", 0);put("green", 0);}};
				for (String game : games) {
					for (String cubes : game.split(", ")) {
						cubes.replaceAll("\\s*","");
						String[] numColor = cubes.split(" ");
						if (numCubesMap.get(numColor[1]) < Integer.parseInt(numColor[0])) {
								numCubesMap.put(numColor[1], Integer.parseInt(numColor[0]));	
						}
					}
				}
				for (int maximum  : numCubesMap.values()) {
					gamePowSum *= maximum;
				}
				sumPowTotal += gamePowSum;
				System.out.print(gamePowSum + "\n");
			}
			reader.close();
			System.out.print("Sum of Games: " + sumPowTotal);
		}
		catch (FileNotFoundException e) {
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
}
