package day4_1;
import java.io.*;
import java.util.*;

public class Main {
	public static void main(String[] args) {
		try {
			BufferedReader reader = new BufferedReader(new FileReader("winning_cards.txt"));
			Hashtable<String, Integer> maximumCubes = new Hashtable<>();
			String line;
			int sumPoints = 0;
			boolean oneNumberMatched;
			while ((line = reader.readLine()) != null) {
				int points = 0;
				oneNumberMatched = false;
				String removedCardNum = line.replaceAll("Card [0-9]+:\\s+", "");
				String[] numbersArray = removedCardNum.split("\\| ");
				String[] winningNumbers = numbersArray[0].split("\\s+");
				String[] cardNumbers = numbersArray[1].split("\\s+");
				for (String winningNumber : winningNumbers) {
					for (String cardNumber : cardNumbers) {
						if (winningNumber.equals(cardNumber)) {
							if (oneNumberMatched)
								points *= 2;
							else {
								points += 1;
								oneNumberMatched = true;
							}
						}
					}
				}
				sumPoints += points;
			}
			System.out.println(sumPoints);
		}
		catch (FileNotFoundException e) {
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
}
