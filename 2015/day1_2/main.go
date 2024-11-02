package main

import (
	"bufio"
	"fmt"
	"io"
	"log"
	"os"
)

func main() {
	file, ferr := os.Open("input.txt")
	if ferr != nil {
		panic(ferr)
	}
	scanner := bufio.NewReader(file)
	r := bufio.NewReader(scanner)
	count := 0
	current_floor := 0
	for {
		if c, _, err := r.ReadRune(); err != nil {
			if err == io.EOF {
				break
			} else {
				log.Fatal(err)
			}
		} else {
			if string(c) == "(" {
				current_floor += 1
			} else if string(c) == ")" {
				current_floor -= 1
			}
			count += 1
			if current_floor == -1 {
				fmt.Printf("Entered the basement at pos: %d", count)
				return
			}
		}
	}
	fmt.Printf("Final Floor:  %d\n", current_floor)
}
