# Flappy Bird 2

## Beschreibung des Spiels (inhaltlich/Spielziel; Genre und sonstige Eckdaten/Klassifizierungen)

Flappy Bird 2 ist ein Singleplayer-Spiel, welches in die klassischen Genres Geschicklichkeit und Jump & Run hineinfällt. Es wurde in einem schlichtem und ästhetischem 2D Grafikstil gehalten und das Spielgeschehen verläuft von links nach rechts.

Es gibt es keine Sieg-Bedingung - das Ziel ist es so viele Punkte zu sammeln wie man kann und somit einen neuen Highscore zu erstellen. Auf dem Weg zum Highscore muss man jedoch in der Luft bleiben und verschiedenen Hindernissen ausweichen, die einem entgegen kommen. Das schafft man, indem man durch Flügelschläge in die Höhe flattert und sich gekonnt in jede zweidimensionale Richtung bewegt, um möglichst keinen Schaden zu erleiden. Durch das Aufsammeln von verschiedenen Items kann man sich dabei das Leben erleichtern und sich zur Hölle machen.


## Spielmechaniken

Beim Starten jedes Versuchs hat man 3 Leben. Durch das Sammeln des "Leben"-Items kann man die Anzahl seiner Leben erhöhen, jedoch kann man maximal nur 5 Leben haben. Fliegt man gegen ein Hindernis oder erleidet Schaden indem man gegen die Decke oder auf den Boden fliegt, verliert man ein Leben. Nach jedem Lebensverlust ist man für ein paar Sekunden unverwundbar, damit man sich wieder aufraffen kann. Hat man keine übrigen Leben mehr, heißt es beim nächsten Schadenerlitt Game Over.

Im Verlauf des Spiels kann man unterschiedlichste Items sammeln:
<li>Leben: Man erhält ein zusätzliches Leben
<li>Feder: Man wird für kurze Zeit leichter und kann somit mit einem Flügelschlag höher kommen und sich schneller nach links oder rechts bewegen
<li>Eisenkugel: Man wird für kurze Zeit schwerer und muss somit häufiger mit dem Flügel schlagen, um hoch zu kommen. Zudem fällt man schneller auf den Boden und man beweget sich langsamer nach links und rechts
<li>Schild: Man wird für kurze Zeit unverwundbar
<li>Kleiner Trank: Man wird permanent kleiner und passt leichter durch die Lücken der Hindernisse
<li>Mittlerer Trank: Man versetzt sich in die ursprüngliche Größe
<li>Großer Trank: Man wird signifikant größer und es wird schwerer durch die Lücken zu passen

Aktuelle Lebensanzeige und aktueller Score wird unten im Spiel angezeigt. Den Highscore kann man im Menü unter Optionen einsehen, wo man auch Sound und Musik aus, bzw. anmachen kann.

Die Figur steuert man über WASD oder die Pfeiltasten. Mit W oder Pfeiltaste nach oben kann man einen Flügelschlag machen und kann sich somit in der Höhe halten. Die Schwerkfrat zieht den Charakter automatisch Richtung Boden, allerdings kann man auch schneller gen Boden mittels "S" oder Pfeiltaste nach unten kommen. Mit "A", "D", Pfeiltasten nach rechts und links kann man sich seitlich bewegen. Während des Spiels kann man über "P" oder Escape kann man das Spiel pausieren und gegebenenfalls beenden und ins Hauptmenü zurückkehren.

Je weiter man kommt, desto schwieriger wird es den Hindernissen auszuweichen. Die Abstände zwischen zwei spawnenden Hindernissen verringern sich, die Geschwindigkeit mit der sie auf dich zukommen wird höher und die Größe der Lücke ist ebenfalls variabel. Nach einem bestimmtem Zeitpunkt bewegen sich die Hindernisse nicht nur von links nach rechts sondern auch von oben nach unten (beziehungsweise umgekehrt).



## Technische Features

Im folgenden werden die technischen Features aufgezählt und dazu geschrieben, welche Person diese implementiert hat. Die Namen der Personen werden abgekürzt: Burak Sahan (B), Konstantin Kulik (K), Melanie Kloss (M), Sabrina Hartl (S) und Vera Wittmann (V).

<li> Bewegung von Boden, Himmel und Obstacles von rechts nach links (B)(K)(M)(S)(V)
<li> Änderung der Größe der Spielfigur bei Aufnehmen von unterschiedlichen Items (K)
<li> Figur kann nicht über die Obstacles hinaus fliegen (K)
<li> Randomisiertes Spawnen von Items (S)
<li> Spielfiguranimationen (B)(M)
<li> Lebensanzeige (B)
<li> Lebenszähler bei Verlust oder Erhalt von Leben (B)
<li> Startmenü (V)
<li> Pausemenü inklusive Pausieren des Spiels im Hintergrund (V)(K)
<li> Einfügen aller Items (S)
<li> Spielfigur bleibt innerhalb der Kamera (K)
<li> Hindernisspwan (V)
<li> Hindernisse werden mit der Zeit nach einer bestimmtem Funktion schneller (K)
<li> Abstand zwischen Hindernissen werden mit der Zeit nach einer bestimmtem Funktion kleiner (K)
<li> Hindernisse bewegen sich nach einer bestimmten Zeit zusätzlich von oben nach unten und umgekehrt (M)(K)
<li> Bewegung der Hindernisse von oben nach unten und umgekehrt wird mit der Zeit schneller (K)
<li> Lücke bei Hindernissen variiert (M)
<li> Speichern des Highscores (V)
<li> Resetten des Highscores (V)
<li> Einfügen der Musik und Soundeffekte (V)
<li> Erhöhung des Hindernispools (M)
<li> Steuerung der Spielfigur (K)
<li> Neigung der Spielfigur gen Boden beim Fallen (K)
<li> Spawnalgorithmus der Items (B)(S)
<li> Asseterstellung & Grafikstil (M)
<li> Parallax Effekt (M)
<li> Partikeleffekt: Leichter Ascheregen angelehnt an die Vulkanlandschaft im Hintergrund
