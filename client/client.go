package main

import (
	//"time"
	//"encoding/json"

	"bytes"
	"encoding/json"
	"fmt"
	"io/ioutil"
	"net/http"
	"net/url"
)

//var Db *gorm.DB //this is Db pool variable

type Gamedata struct {
	GameID   string  `json:"gameID"`
	FieldX   int     `json:"fieldX"`
	FieldY   int     `json:"fieldY`
	Player1  string  `json:"player1"`
	Player2  string  `json:"player2"`
	Status   bool    `json:"status"`
	P1field  [][]int `json:"p1field"`
	P2field  [][]int `json:"p2field"`
	Reserved string  `json:"reserved"`
}

var A Gamedata

func gamestart() int {
	data := url.Values{
		"field1": {"Some Values"},
		"field2": {"gardener"},
	}
	//resp, _ := http.PostForm("http://localhost:8081/", data)
	resp, _ := http.PostForm("http://sb.mailboxly.info:80/", data)

	buf := new(bytes.Buffer)
	buf.ReadFrom(resp.Body)
	a := buf.String()

	//fmt.Println(a)

	url := "http://sb.mailboxly.info/?gameid=" + a
	//url := "http://localhost:8081/?gameid=" + a
	//fmt.Println(url)
	resp, _ = http.Get(url)
	body, _ := ioutil.ReadAll(resp.Body)
	_ = json.Unmarshal(body, &A)
	fmt.Println("-----------ID игры:", a, "-----------------")
	fmt.Println("Игрок1: ", A.Player1, "Игрок2: ", A.Player2)
	fmt.Println("- - - - - - - - - - - - - - - - - - - -")
	for i := 0; i < 5; i++ {
		fmt.Println(A.P1field[0:][i], "      ", A.P2field[0:][i])

	}
	return 1
}

//func gamehit()

func main() {
	var st string
	var xhit, yhit int
	fmt.Println("пишем клиента")
	fmt.Print("хотите начать игру с сервером http://localhost:8081 , (Y/N)")

	fmt.Scanf("%s", &st)
	switch st {
	case "Y":
		fmt.Println("Вы хотите", st)
		fmt.Println("Вы хотите!!!", st)
		_ = gamestart()
	case "N":
		fmt.Println("Вы НЕ хотите", st)
	default:
		fmt.Println("Определитесь со своим решением...")
	}

	for active := 1; active == 1; active = 1 {
		fmt.Print("делайте ход, введите Х ")
		fmt.Scan(&xhit)
		fmt.Print("а теперь введите Y ")
		fmt.Scan(&yhit)
		fmt.Println(xhit, ":", yhit)
		//_ = gamehit(xhit, yhit)
	}

}
