#!/bin/bash
#
# mlz.sh
#   MLZ
#
# 17.06.2017 / Serafino Fornito
#
if [ "$1" == "dev" ]
then
  bashbeautify mlz.sh
  kwrite mlz.sh
  exit 0;
fi

# Variablen--------------------------------------------------------------------------------------------------------------------------
TITLE="**** Menu ****"
STUNDE=$(date +%H)

# Farben---------------------------------------------------------
NC="\033[0m"						#keine Farbe
GREEN="\033[0;32m"			#Grün
ORANGE="\033[0;33m"		#Orange
RED="\033[0;31m"				#Rot normal

# Funktionen------------------------------------------------------------------------------------------------------------------------
function getSystemInfos() {
  SYSINFO=$(head -n 1 /etc/issue)
  IFS=$'\n'
  UPTIME=$(uptime)
  D_UP=${UPTIME:1}
  DATE=$(date)
  KERNEL=$(uname -a)
  CPU=$(arch)

  printf "<=== SYSTEM ===>\n"
  printf "  Distro info:\t%s\n" "$SYSINFO"
  printf "  Kernel:\t%s\n" "$KERNEL"
  printf "  Uptime:\t%s\n" "$D_UP"
  free -mt | awk '
	/Mem/{
		print "  Memory:\tTotal: " $2 "Mb\tUsed: " $3 "Mb\tFree: " $4 "Mb"
	}
	/Swap/{
		print "  Swap:\t\tTotal: " $2 "Mb\tUsed: " $3 "Mb\tFree: " $4 "Mb"
  }'
  printf "  Architecture:\t%s\n" "$CPU"
  cat /proc/cpuinfo | grep "model name\|processor" | awk '
	/processor/{
		printf "  Processor:\t" $3 " : "
	}
	/model\ name/{
		i=4
		while(i<=NF){
			printf $i
			if(i<NF){
				printf " "
			}
			i++
		}
		printf "\n"
	}'
  printf "  Date:\t\t%s\n" "$DATE"
}

function randomPW() {
  case $2 in
    1)
      < /dev/urandom tr -dc a-z0-9 | head -c${1:-$1}
      ;;
    2)
      < /dev/urandom tr -dc A-Za-z0-9 | head -c${1:-$1}
      ;;
    3)
      < /dev/urandom tr -dc _A-Z-a-z-0-9 | head -c${1:-$1}
      ;;
  esac
}

# Der Array fuer das Menu------------------------------------------------------------------------------------------------------------------------
MENU=(
  "Willkommen"
  "Sichern der aktuellen Prozesshierarchie sowie der Systemlast"
  "Zeige Soft- & Hardwareinfos"
  "Zahlenreihe"
  "Countdown"
  "Passwortgenerator"
  "Spielereien"
  "Hilfe"
  "Beenden"
)
# Anzahl Elemente des Arrays MENU
ANZAHL=${#MENU[*]}

# Eingabe verlangen und einlesen
echo -n "Bitte geben Sie Ihren Namen ein: "
read -r NAME

# Beginn des Programmes------------------------------------------------------------------------------------------------------------------------
# Schlaufe fuer das Menue
while true; do
clear
  # Menu ausgeben
  printf "%s\n\n" "$TITLE"

  for ((i=1; $((i<=ANZAHL)); i=$((i+1)))); do
    echo "$i) ${MENU[$i-1]}"
  done

  stty echo
  # Eingabe verlangen und einlesen
  echo -n "Auswahl eingeben, mit ENTER bestätigen: "
  read -r ANTWORT

  clear

  if (("$ANTWORT" > 0 && "$ANTWORT" <= "$ANZAHL"))
  then
	printf "\n=> %s\n\n" "${MENU[$ANTWORT-1]}"
	fi
  case $ANTWORT in
    1) # Willkommen
      if (("0"<="$STUNDE" && "$STUNDE"<="5"))
      then
        echo "$NAME, solltest du nicht eigentlich längst im Bett sein?!"
      elif (("6"<="$STUNDE" && "$STUNDE"<="12"))
      then
        echo "Guten Morgen $NAME"
      elif (("13"<="$STUNDE" && "$STUNDE"<="17"))
      then
        echo "Guten Tag $NAME"
      else
        echo "Guten Abend $NAME"
      fi
      ;;
    2) # Sichern der aktuellen Prozesshierarchie sowie der Systemlast
      top -n 1 -b > ~/bin/processor-log.txt
      cat ~/bin/processor-log.txt
      ;;
    3) # Zeige Soft- & Hardwareinfos
      getSystemInfos
      ;;
    4) # Zahlenreihe

      ;;
    5) # Countdown
      while ! dpkg -l | grep -qw sox || ! dpkg -l | grep -qw espeak
      do
        printf "Es fehlt mindestens ein Packet um beim Countdown Ton abzuspielen.\nMöchten Sie diese Installieren? [Y/N]\n"
        read -r ANSWER
        if [[ $ANSWER == [Yy] ]]
        then
          dpkg -l | grep -qw sox || sudo apt-get install espeak
          dpkg -l | grep -qw sox || sudo apt-get install sox
          #https://www.freesoundeffects.com/music_8728526119466456_file7d0665438e81d8eceb98c1e31fca80c1.wav
        elif [[ $ANSWER == [Nn] ]]
        then
          break
        else
          printf "Ungültige Auswahl"
        fi
        clear
      done

      echo -n "Geben Sie die Start-Zahl ein:  "
      read -r STARTNUMBER

      echo -n "Geben Sie den gewünschten Takt in Sekunden ein:  "
      read -r SLEEP

      echo -n "Wünschen Sie Tonwiedergabe? Für 'Ja' drücken Sie die Taste[Y]"
      read -n 1 -r ANSWER
      clear

      stty -echo
      for(( i=$((STARTNUMBER)); i > 0; i-- )); do
        printf "   %s \r" "$i"
        if [[ $ANSWER == [Yy] ]] && dpkg -l | grep -qw sox && dpkg -l | grep -qw espeak
        then
          espeak $i&
        fi
        sleep "$SLEEP"
      done
      printf "   BOOOOOOOOM!!! \r"
      if [[ $ANSWER == [Yy] ]] && dpkg -l | grep -qw sox && dpkg -l | grep -qw espeak
      then
        play -q ~/Downloads/explosion_11.wav
      else
        sleep 3
      fi
      clear
      ;;
    6) # Passwortgenerator
     echo "Bitte wählen Sie die Länge Passwortes aus: "
      read -r LENGTH
      echo "Bitte wählen Sie das Sicherheitslevel des Passwortes aus: "
      printf "1)${RED} Leicht ${NC}\n"
      printf "2)${ORANGE} Mittel ${NC}\n"
      printf "3)${GREEN} Stark ${NC}\n"
      read -r LEVEL

      if (("$LEVEL" > "0" && "$LEVEL" <= "3"))
      then
        randomPW "$LENGTH" "$LEVEL"
      else
        echo "Ungültige Auswahl"
        stty -echo
        sleep 3
      fi
      echo
      ;;
    7) # Spielereien

      ;;
    8) # Hilfe
      ls -l ~/bin/*.sh
      echo ""
      ;;
    9) # Beenden
      exit 0;
      ;;
    *) # Ungültige Auswahl
      echo "Ungültige Auswahl"
      ;;
  esac
  
  read -n 1 -s -p "Drücken Sie eine Taste um fortzuführen."
  cols=$(tput cols)
  i=0
  echo
  while [ "$i" -lt "$cols" ]
  do echo -n "-"
    i=$((i + 1))
  done
  echo
  echo
done