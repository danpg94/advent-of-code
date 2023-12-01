package day1;

import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.BufferedReader;
import java.io.IOException;

public class Main {
	public static void main(String[] args ) {
		try {
			BufferedReader reader = new BufferedReader(new FileReader("calibration_values.txt"));
			String line;
			StringBuilder builder = new StringBuilder();
			int sum = 0, lineNumber = 0;
			char first = '\0', second = '\0';
			while((line = reader.readLine()) != null) {
				System.out.print(line + "\n");
				boolean foundFirstNum = false;
				for (char x : line.toCharArray()) {
					if (Character.isDigit(x)) {
						if (foundFirstNum) {
							second = x;
						} else {
							first = x;
							second = x;
							foundFirstNum = true;
						}
					}
				}
				lineNumber = Integer.parseInt(builder.append(first).append(second).toString());
				sum += lineNumber;
				System.out.println(lineNumber);
				builder.setLength(0);
			}
			System.out.println(sum);
			
			
			reader.close();
		}
		catch (FileNotFoundException e) {
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		
			
	}
}
