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
		}
	}
	fmt.Printf("Final Floor:  %d\n", current_floor)
}
