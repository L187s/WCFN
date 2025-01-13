#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
int main()
{
    bool is_in_Menu = true;
    
    char Eingabe_Menu;


    printf("||WINDOWS COMANDS FOR NOOBS||\n\n");
    printf("1.) System and Network information");
    scanf("%c",&Eingabe_Menu);



    switch (Eingabe_Menu)
    {
    case '1':
    system("cls");
    printf("||CHOOSE AN COMMAND||\n\n");
    printf("1.) ipconfig\nDescription: Displays the system's network configuration, including IP address.");
    printf("2.) ping\nDescription: tests the connection to an IP address or domain. Example: ping google.com. ");
    printf("3.) tracert\nDescription: Traces the path of data packets to a destination. Example: tracert google.com.");
    scanf("%c",&Eingabe_Menu);

    switch(Eingabe_Menu)
    {
        case '1':
        system("ipconfig /all");
        break;

        case '2':
        system("ping www.google.com");
        break;

        case '3':
        system("tracert www.google.com");
    }


        break;


    default:
    
    printf("Please enter a Valid Number\a");
        break;
    }

    return 0;
}