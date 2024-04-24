#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include <stdbool.h>
#include <arpa/inet.h>

#include "board.h"

const int MAX = 10000;
const int MIN = -10000;

int max(int a, int b) {
  return (a > b) ? a : b;
}

int min(int a, int b) {
  return (a < b) ? a : b;
}


typedef struct 
{
  int board[5][5];
} position;

int positionGrade(position p)
{
  for(int i=0; i<28; i++)
    if( (p.board[win[i][0][0]][win[i][0][1]]==1) && (p.board[win[i][1][0]][win[i][1][1]]==1) && (p.board[win[i][2][0]][win[i][2][1]]==1) && (p.board[win[i][3][0]][win[i][3][1]]==1) )
      return MAX;

  for(int i=0; i<28; i++)
    if( (p.board[win[i][0][0]][win[i][0][1]]==2) && (p.board[win[i][1][0]][win[i][1][1]]==2) && (p.board[win[i][2][0]][win[i][2][1]]==2) && (p.board[win[i][3][0]][win[i][3][1]]==2) )
      return MIN;

  for(int i=0; i<48; i++)
    if( (p.board[lose[i][0][0]][lose[i][0][1]]==1) && (p.board[lose[i][1][0]][lose[i][1][1]]==1) && (p.board[lose[i][2][0]][lose[i][2][1]]==1) )
      return MIN;

  for(int i=0; i<48; i++)
    if( (p.board[lose[i][0][0]][lose[i][0][1]]==2) && (p.board[lose[i][1][0]][lose[i][1][1]]==2) && (p.board[lose[i][2][0]][lose[i][2][1]]==2) )
      return MAX;

  int grade = 0;
  for(int i=0; i<28; i++)
    if( (p.board[win[i][0][0]][win[i][0][1]]!=2) && (p.board[win[i][1][0]][win[i][1][1]]!=2) && (p.board[win[i][2][0]][win[i][2][1]]!=2) && (p.board[win[i][3][0]][win[i][3][1]]!=2) )
      grade++;


  for(int i=0; i<28; i++)
    if( (p.board[win[i][0][0]][win[i][0][1]]!=1) && (p.board[win[i][1][0]][win[i][1][1]]!=1) && (p.board[win[i][2][0]][win[i][2][1]]!=1) && (p.board[win[i][3][0]][win[i][3][1]]!=1) )
      grade--;

  return grade;
}

int minmaxrec(position p, int depth, int alpha, int beta, bool maximizingPlayer)
{
  if (depth == 0 || positionGrade(p) == MIN || positionGrade(p) == MAX)
    return positionGrade(p);
  

  bool breakHelp = false;

  if(maximizingPlayer)
  {
    int maxEval = MIN;
    for(int i=0; i<5; i++)
    {
      for(int j=0; j<5; j++)
      {
        if(p.board[i][j] == 0)
        {
          position child = p;
          child.board[i][j] = 1;
          

          int eval = minmaxrec(child, depth-1, alpha, beta, false);
          maxEval = max(maxEval, eval);
          alpha = max(alpha, eval);

          if (beta <= alpha)
          {
            breakHelp = true;
            break;
          } 
        }
      }
      if(breakHelp)
      {
        breakHelp = false;
        break;
      }
      
    }
    return maxEval;
  }
  else
  {
    int minEval = MAX;
    for(int i=0; i<5; i++)
    {
      for(int j=0; j<5; j++)
      {
        if(p.board[i][j] == 0)
        {
          position child = p;
          child.board[i][j] = 2;

          int eval = minmaxrec(child, depth-1, alpha, beta, true);
          minEval = min(minEval, eval);
          beta = min(beta, eval);

          if (beta <= alpha)
          {
            breakHelp = true;
            break;
          } 
        }
      }
      if(breakHelp)
      {
        breakHelp = false;
        break;
      }
      
    }
    return minEval;
  }

  return 1234;
}

int minmax(position p, int depth, int player)
{
  if (!(player == 1 || player == 2)) return -1;

  if (depth == 0 || positionGrade(p) == MIN || positionGrade(p) == MAX) return positionGrade(p);

  int move;
  for(int i=0; i<5; i++)
  {
    for(int j=0; j<5; j++)
    {
      if(p.board[i][j]==0)
       move = (i+1)*10+j+1;
    }
  }
      
        

  if(player == 1)
  {
    int maxEval = MIN;
    for(int i=0; i<5; i++)
    {
      for(int j=0; j<5; j++)
      {
        if(p.board[i][j] == 0)
        {
          position child = p;
          child.board[i][j] = 1;
          

          int eval = minmaxrec(child, depth-1, maxEval, MAX, false);
          if(eval > maxEval)
          {
            move = (i+1)*10+j+1;
            maxEval = eval;
          }
        }
      }
    }
  }
  else
  {
    int minEval = MAX;
    for(int i=0; i<5; i++)
    {
      for(int j=0; j<5; j++)
      {
        if(p.board[i][j] == 0)
        {
          position child = p;
          child.board[i][j] = 2;
          

          int eval = minmaxrec(child, depth-1, MIN, minEval, true);
          if(eval < minEval)
          {
            move = (i+1)*10+j+1;
            minEval = eval;
          }
        }
      }
    }
  }

  return move;
}

int main(int argc, char *argv[])
{
  int socket_desc;
  struct sockaddr_in server_addr;
  char server_message[16], client_message[16];

  bool end_game;
  int player, depth, msg, move;

  if( argc!=5 ) {
    printf("Wrong number of arguments\n");
    return -1;
  }

  // Create socket
  socket_desc = socket(AF_INET, SOCK_STREAM, 0);
  if( socket_desc<0 ) {
    printf("Unable to create socket\n");
    return -1;
  }
  printf("Socket created successfully\n");

  // Set port and IP the same as server-side
  server_addr.sin_family = AF_INET;
  server_addr.sin_port = htons(atoi(argv[2]));
  server_addr.sin_addr.s_addr = inet_addr(argv[1]);

  // Send connection request to server
  if( connect(socket_desc, (struct sockaddr*)&server_addr, sizeof(server_addr))<0 ) {
    printf("Unable to connect\n");
    return -1;
  }
  printf("Connected with server successfully\n");

  // Receive the server message
  memset(server_message, '\0', sizeof(server_message));
  if( recv(socket_desc, server_message, sizeof(server_message), 0)<0 ) {
    printf("Error while receiving server's message\n");
    return -1;
  }
  printf("Server message: %s\n",server_message);

  memset(client_message, '\0', sizeof(client_message));
  strcpy(client_message, argv[3]);
  // Send the message to server
  if( send(socket_desc, client_message, strlen(client_message), 0)<0 ) {
    printf("Unable to send message\n");
    return -1;
  }

  setBoard(); 
  end_game = false;
  player = atoi(argv[3]);
  depth = atoi(argv[4]);

  while( !end_game ) {
    memset(server_message, '\0', sizeof(server_message));
    if( recv(socket_desc, server_message, sizeof(server_message), 0)<0 ) {
      printf("Error while receiving server's message\n");
      return -1;
    }
    printf("Server message: %s\n", server_message);
    msg = atoi(server_message);
    move = msg%100;
    msg = msg/100;
    if( move!=0 ) {
      setMove(move, 3-player);
      printBoard();
    }
    if( (msg==0) || (msg==6) ) {
      printf("Your move: ");


      position p;
      for(int i=0;i<5;i++)
      {
        for(int j=0;j<5;j++)
        {
          p.board[i][j] = board[i][j];
        }
      }

      move = minmax(p, depth, player);
      setMove(move, player);
      printf("%d\n", move);
      printBoard();
      memset(client_message, '\0', sizeof(client_message));
      sprintf(client_message, "%d", move);
      if( send(socket_desc, client_message, strlen(client_message), 0)<0 ) {
        printf("Unable to send message\n");
        return -1;
      }
      printf("Client message: %s\n", client_message);
     }
     else {
       end_game = true;
       switch( msg ) {
         case 1 : printf("You won.\n"); break;
         case 2 : printf("You lost.\n"); break;
         case 3 : printf("Draw.\n"); break;
         case 4 : printf("You won. Opponent error.\n"); break;
         case 5 : printf("You lost. Your error.\n"); break;
       }
     }
   }

  // Close socket
  close(socket_desc);

  return 0;
}
