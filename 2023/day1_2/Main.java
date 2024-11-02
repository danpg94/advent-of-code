package day1_2;

import java.io.*;
import java.util.Hashtable;
import java.util.Set;
import java.util.AbstractMap;

public class Main {
	
	public static AbstractMap.SimpleEntry<Character, Integer> isStrNumber(Hashtable<String, Character> strNumbers, String str, Integer pos) {
		// System.out.println(strNumbers);
		AbstractMap.SimpleEntry<Character, Integer> result;
		Set<String> stringSet = strNumbers.keySet();
		for (String name : stringSet) {
			int endPos = pos + name.length();
		//  System.out.println("String: " + str + " Pos: " + pos + " endPos: " + endPos);
			if (endPos <= str.length()) {
				String substring = str.substring(pos, endPos);
				// System.out.println(substring);
				if (name.equals(substring)) {
					result = new AbstractMap.SimpleEntry<Character, Integer>(strNumbers.get(name), endPos);
					return result;
				}
			}
		}
		result = new AbstractMap.SimpleEntry<Character, Integer>('0', -1);
		return result;
	}
	
	public static void main(String[] args ) {
		try {
			Hashtable<String, Character> strNumbers = new Hashtable<>();
			strNumbers.put("one", '1');
			strNumbers.put("two", '2');
			strNumbers.put("three", '3');
			strNumbers.put("four", '4');
			strNumbers.put("five", '5');
			strNumbers.put("six", '6');
			strNumbers.put("seven", '7');
			strNumbers.put("eight", '8');
			strNumbers.put("nine", '9');
			// System.out.println(strNumbers);
			
			BufferedReader reader = new BufferedReader(new FileReader("calibration_values.txt"));
			String line;
			StringBuilder builder = new StringBuilder();
			int sum = 0, lineNumber = 0;
			char first = '\0', second = '\0';
			while((line = reader.readLine()) != null) {
				// System.out.print(line + "\n");
				boolean foundFirstNum = false;
				
				for (int i = 0; i<line.length(); i++) {
					if (Character.isDigit(line.charAt(i))) {
						if (foundFirstNum) {
							second = line.charAt(i);
						} else {
							first = line.charAt(i);
							second = line.charAt(i);
							foundFirstNum = true;
						}
					} else {	
						AbstractMap.SimpleEntry<Character, Integer> temp = isStrNumber(strNumbers ,line, i);
						// System.out.println(line + " " + i + " " + temp);
						if (temp.getKey() != '0') {
							if (foundFirstNum) {
								second = temp.getKey();
								i = temp.getValue() - 1; 
							} else {
								first = temp.getKey();
								second = temp.getKey();
								i = temp.getValue() - 1;
								foundFirstNum = true;
							}
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

