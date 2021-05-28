package main

import (
	"encoding/json"
	"fmt"
	"log"
	"net/http"

	seabattle "github.com/mntcalm/Seabattle"
)

func newGame(w http.ResponseWriter, r *http.Request) {
	fmt.Fprintf(w, "gameID")
}

func next(w http.ResponseWriter, r *http.Request) {
	resp := seabattle.BattleField{
		Field: [][]int{
			{1, 2, 3},
			{1, 2, 3},
			{1, 1, 0},
		},
	}

	w.Header().Set("Content-Type", "application/json")
	json.NewEncoder(w).Encode(resp)
}

func mux(w http.ResponseWriter, r *http.Request) {
	switch r.Method {
	case http.MethodPost:
		newGame(w, r)
	case http.MethodGet:
		next(w, r)
	}

}

func main() {
	http.HandleFunc("/", mux)
	if err := http.ListenAndServe(":8080", nil); err != nil {
		log.Fatal(err)
	}
}
