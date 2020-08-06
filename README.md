# Flappy Dragon

## Team

| <img alt="Portrait von Sabrina" src="Images/Teamfotos/Sabrina-Hartl.jpg" width="200" /> | <img alt="Portrait von Melanie" src="Images/Teamfotos/melanie-kloss.jpg" width="200" /> | <img alt="Portrait von Konstantin" src="Images/Teamfotos/Konstantin-Kulik_quadrat.jpg" width="200" /> |
|:-----------------:|:-----------------:|:-----------------:|
| **Sabrina Hartl**<br/> Matrikelnummer: XXX <br/> E-Mail: sabrina1.hartl@stud.uni-regensburg.de <br/>Github-Nutzer: 96Sabiii |  **Melanie Kloss** <br/> Matrikelnummer: XXX <br/> E-Mail: melanie.kloss@stud.uni-regensburg.de <br/>Github-Nutzer: AboutWhite | **Konstantin Kulik**<br/> Matrikelnummer: 1866957 <br/> E-Mail: konstantin.kulik@stud.uni-regensburg.de <br/>Github-Nutzer: Kotjik |


| <img alt="Portrait von Burak" src="Images/Teamfotos/burak-sahan.jpg" width="200" /> | <img alt="Portrait von Vera" src="Images/Teamfotos/vera-wittmann.jpg" width="200" /> |
|:-----------------:|:-----------------:|
| **Burak Sahan**  <br/> Matrikelnummer: XXX <br/> E-Mail: burak.sahan@stud.uni-regensburg.de <br/>Github-Nutzer: buraks95 | **Vera Wittmann**  <br/> Matrikelnummer: XXX <br/> E-Mail: vera1.wittmann@stud.uni-regensburg.de <br/>Github-Nutzer: veraarev |

## Beschreibung des Spiels 

Flappy Dragon ist ein Singleplayer-Spiel, welches in die klassischen Genres Geschicklichkeit und Jump & Run fällt. Es wurde in einem schlichten und ästhetischen 2D Grafikstil gehalten und das Spielgeschehen verläuft von links nach rechts.

<p align=center>
<img src="ReadMe_Assets/start.gif" width="400">
</p>

Es gibt es keine Sieg-Bedingung - das Ziel des Spiels ist es so viele Punkte wie möglich zu sammeln und somit einen neuen Highscore zu erreichen. Auf dem Weg zum Highscore muss der Spieler in der Luft bleiben und verschiedenen Hindernissen ausweichen, welche ihm entgegenkommen. Durch drücken der entsprechenden Tasten kann der Spieler mit kräftigen Flügelschlägen in die Höhe flattert, schneller abstürzen und sich auch nach rechts und links bewegen, um möglichst keinen Schaden zu erleiden. Durch das Aufsammeln von verschiedenen Items kann sich der Spieler dabei das Leben erleichtern oder zur Hölle machen.


## Spielmechaniken

Zu Beginn des Spiels hat man 3 Leben.

Durch das Sammeln des "Herz"-Items kann man die Anzahl der Leben erhöhen, jedoch ist die maximale Anzahl an Leben auf 5 begrenzt. Fliegt man gegen ein Hindernis oder erleidet Schaden indem man gegen die Decke oder den Boden fliegt, verliert man ein Leben.

<p align=center>
<img src="ReadMe_Assets/lostLife.gif?raw=true" width="400">
</p>

Durch erfolgreiches Durchfliegen eines Hindernisses kann der Spieler Scorepunkte sammeln.
<p align=center>
<img src="ReadMe_Assets/point.gif" width="400">
</p>

Nach jedem Lebensverlust ist der Spieler für ein paar Sekunden unverwundbar. Hat er keine Leben mehr übrig, heißt es beim nächsten Schaden "Game Over".
<p align=center>
<img alt="Game Over" src="ReadMe_Assets/gameOver.PNG" width="400"/>
</p>

Schafft der Spieler es nicht rechtzeitig durch ein Hindernis und droht aus dem Fenster zu steuern, wird er vom linken Rand durch die nächsten Hindernisse geschoben - verliert allerdings dadurch auch immer ein Leben.
<p align=center>
<img src="ReadMe_Assets/hindernis.gif" width="400">
</p>

Im Verlauf des Spiels kann man verschiedene Items mit unterschiedlichen Funktionen sammeln:

| Bild | Aussehen | Funktion|
| :------: | :------: | ----- |
| <img alt="Herz" src="Assets\NewAssets\Sprites\Items\Herz item.png" height="30" />| Herz | Spieler erhält ein zusätzliches Leben. |
| <img alt="Feder" src="Assets\NewAssets\Sprites\Items\Feather.png" height="30" /> | Feder| Spieler wird für kurze Zeit leichter und kann somit mit einem Flügelschlag höher fliegen und sich schneller nach links oder rechts bewegen. |
| <img alt="Eisenkugel" src="Assets\NewAssets\Sprites\Items\Kette.png" height="25" /> | Eisenkugel | Spieler wird für kurze Zeit schwerer und muss somit häufiger mit dem Flügel schlagen, um hoch zu kommen. Zudem fällt man schneller auf den Boden und er bewegt sich langsamer nach links und rechts. |
| <img alt="Schild" src="Assets\NewAssets\Sprites\Items\shield.png" height="30" /> | Schild | Spieler wird für kurze Zeit unverwundbar. |
| <img alt="Kleiner Trank" src="Assets\NewAssets\Sprites\Items\smaler.png" height="30" /> | Kleiner Trank | Spieler wird permanent kleiner und passt so leichter durch die Lücken der Hindernisse. |
| <img alt="Mittlerer Trank" src="Assets\NewAssets\Sprites\Items\normal.png" height="30" /> | Mittlerer Trank | Spieler bekommt wieder die ursprüngliche Größe. |
| <img alt="Großer Trank" src="Assets\NewAssets\Sprites\Items\bigger.png" height="30" /> | Großer Trank | Spieler wird signifikant größer und es wird schwerer durch die Lücken der Hindernisse zu passen. |


Die Anzeige der aktuellen Leben und der aktuelle Score werden unten im Spiel angezeigt. Den Highscore kann man im Hauptmenü unter Optionen einsehen. Das Spiel selbst wird ebenfalls über das Hauptmenü gestartet.
<p align=center>
<img alt="Game Over" src="ReadMe_Assets/start.PNG" width="400" style="align:center"/>
</p>

Dort kann man auch Einstellungen zu Highscore, Sound und Musik vornehmen, die Steuerung einsehen oder das Spiel beenden.
<p align=center>
<img alt="Game Over" src="ReadMe_Assets/settings.PNG" width="400" style="align:center"/>
</p>

Der Dragon kann über WASD oder die Pfeiltasten gesteuert werden. Mit "W" / ↑ macht der Dragon einen Flügelschlag und kann sich somit in der Höhe halten. Die Schwerkraft zieht den Charakter automatisch Richtung Boden, allerdings kann der Spieler auch schneller gen Boden mittels "S" / ↓ steuern. Mit "A" / ← und "D" / → kann sich der Spieler seitlich bewegen.
<p align=center>
<img alt="Game Over" src="ReadMe_Assets/controls.PNG" width="400" style="align:center"/>
</p>

Während des Spiels kann man dieses über "P" oder "Escape" pausieren. Dabei wird das Pause-Menü aufgerufen. Das laufende Spiel wird zum aktuellen Zeitpunkt eingefroren und kann vom Spieler manuell wieder gestartet werden bzw. gegebenenfalls beendet werden, um ins Hauptmenü zurück zu kehren. Außerdem ist es möglich, dass Spiel im Pause-Menü neu zu starten.
<p align=center>
<img alt="Game Over" src="ReadMe_Assets/pause.PNG" width="400" style="align:center"/>
</p>

Je mehr Punkte der Spieler erreicht, desto schwieriger wird es den Hindernissen auszuweichen. Die Abstände zwischen zwei Hindernissen verringern sich, die Geschwindigkeit, mit der sie auf den Spieler zukommen, wird erhöht und die Größe der Lücke zum Durchfliegen variiert. Ab einem bestimmten Score fangen die Hindernisse an, sich neben links und rechts auch von oben nach unten (beziehungsweise umgekehrt) zu bewegen.


## Technische Features und Verteilung der Aufgaben

Im Folgenden werden die technischen Features aufgezählt und beschrieben, welche Person diese implementiert hat. Die Namen der Personen werden abgekürzt: Burak Sahan (B), Konstantin Kulik (K), Melanie Kloss (M), Sabrina Hartl (S) und Vera Wittmann (V). Eine genauere Auflistung sämtlicher Features ist in den Issues zu finden.

<li> Grundspiel: Erstellen der Hindernisse, sich wiederholender Hintergrund, Grundbewegung des Spielers (B)(K)(M)(S)(V)
<li> Bewegung von Boden, Himmel und Obstacles von rechts nach links (B)(K)(M)(S)(V)
<li> Änderung der Größe der Spielfigur bei Aufnehmen von unterschiedlichen Items (K)
<li> Figur kann nicht über die Obstacles hinausfliegen (K)
<li> Randomisiertes Spawnen von Items (S)(B)
<li> Spielfiguranimationen (B)(M)
<li> Lebensanzeige (B)
<li> Lebenszähler bei Verlust oder Erhalt von Leben (B)
<li> Startmenü (V)
<li> Pausemenü inklusive Pausieren des Spiels im Hintergrund (V)(K)
<li> Einfügen aller Items und Zerstörung beim Verlassen der Kamera (S)
<li> Spielfigur bleibt innerhalb der Kamera (K)
<li> Hindernisse werden mit der Zeit nach einer bestimmten Funktion schneller (K)(M)
<li> Abstand zwischen Hindernissen werden mit der Zeit nach einer bestimmten Funktion kleiner (K)(M)
<li> Hindernisse bewegen sich nach einer bestimmten Zeit zusätzlich von oben nach unten und umgekehrt (M)(K)
<li> Bewegung der Hindernisse von oben nach unten und umgekehrt wird mit der Zeit schneller (K)
<li> Lücke bei Hindernissen variiert (M)
<li> Speichern und Resetten des Highscores (V)
<li> Einfügen der Musik und Soundeffekte (V)
<li> Einstellungen zu Musik und Soundeffekten (V)
<li> Steuerungshinweis (V)
<li> Steuerung der Spielfigur (K)
<li> Neigung der Spielfigur gen Boden beim Fallen (K)
<li> Asseterstellung & Grafikstil (M)
<li> Parallax Effekt (M)
<li> Partikeleffekt: Leichter Ascheregen angelehnt an die Vulkanlandschaft im Hintergrund (M)
<li> Partikeleffekt: Splittern von Steinen, wenn der Spieler mit einem Hindernis kollidiert (S)
<li> Partikeleffekt: Vulkanrauch (S)
<li> Partikeleffekt: Vulkanausbruch bei erstmaligen neuem Highscore (S)(V)


## Verwendete Quellen

Für die Entwicklung des Spiels wurden die folgenden Quellen verwendet:

| Inhalt | Quelle |
| ------ | ------ |
| Font | https://fonts.google.com/ |
| Musik | https://www.bensound.com/ |
| Sounds | https://www.noiseforfun.com/ |
