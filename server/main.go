package main

import (
	//"time"
	"encoding/json"
	"fmt"
	"net/http"

	"gorm.io/gorm"
)

var Db *gorm.DB //this is Db pool variable

type Gamedata struct {
	GameID  string  `json:"gameID"`
	FieldX  int     `json:"fieldX"`
	FieldY  int     `json:"fieldY`
	Player1 string  `json:"player1"`
	Player2 string  `json:"player2"`
	Status  bool    `json:"status"`
	P1field [][]int `json:"p1field"`
	P2field [][]int `json:"p2field"`

	Reserved string `json:"reserved"`
}

var A Gamedata

func Show(w http.ResponseWriter, r *http.Request) {
	switch r.Method {
	case http.MethodPost:
		newGame(w, r)
	case http.MethodGet:
		game(w, r)
	case http.MethodPut:
		turn(w, r)
	}

}

func newGame(w http.ResponseWriter, r *http.Request) {
	fmt.Fprintf(w, "AA22DD5511")
	//json.NewEncoder(w).Encode("AA22DD5511")

}
func game(w http.ResponseWriter, r *http.Request) {
	np := r.URL.Query().Get("gameid")
	if np == "AA22DD5511" {
		//println(A.P1field)
		//println(A.P2field)
		//println(A.Player1)
		w.Header().Set("Content-Type", "application/json")
		json.NewEncoder(w).Encode(A)
	}
}

func turn(w http.ResponseWriter, r *http.Request) {

}
func main() {
	fmt.Println("Starting the game server")

	A.P1field = [][]int{{1, 0, 0, 0, 0},
		{0, 0, 0, 1, 0},
		{1, 3, 0, 0, 0},
		{5, 2, 0, 1, 1},
		{4, 5, 0, 2, 0}}
	A.P2field = [][]int{{8, 8, 8, 8, 8},
		{8, 8, 8, 8, 8},
		{8, 2, 8, 2, 8},
		{8, 2, 8, 5, 5},
		{8, 8, 8, 5, 4}}

	A.Player1 = "Grisha"
	A.Player2 = "Ibragim"
	A.Status = true
	A.GameID = "AA22DD5511"
	A.Reserved = "something more is there."
	A.FieldX = 5
	A.FieldY = 5

	fmt.Println("Server started on: http://localhost:8081")

	http.HandleFunc("/", Show)
	//http.HandleFunc("/show", Show)
	http.ListenAndServe("localhost:8081", nil)

}
