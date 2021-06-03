# MorBoy

Stastes of cells:

0 - nothing is here (it is 8 for opponent)
1 - ship/part of ship (it is 8 for opponent)
2 - miss (shot to empty cell)
3 - hit (destroyed part of alive ship)
4 - sunk ship (part of killed ship)
5 - blocked areas near destroyed shop
8 - unknown

POST request for http://sb.mailboxly.info/ requires no data, returns ID of a game
GET request: http://sb.mailboxly.info/?gameid={what POST returns} gets json structure

