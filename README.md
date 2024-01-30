# ProyectoCoder

En el juego controlamos a un pequeño "robot seguidor de línea", un clásico proyecto educativo de electrónica que se puede construir con Arduino.
El objetivo consiste en llegar al final del recorrido siguiendo el camino delimitado por una línea, antes de que se termine el tiempo o su carga de batería.
El contador de tiempo transcurrirá mas rápido si el robot se sale del camino.
Su nivel de carga (vida) está representado por la intensidad y alcance de un foco de luz ubicado sobre el vehículo, esta será la única fuente de iluminación disponible.
Tanto la lámpara como el movimiento del vehículo consumen batería, pero mas fuertemente los impactos, por lo que deberá esquivar los obstaculos del camino, las paredes
y a otros robots detectores la luz (por el momento representados con esferas de colores) que intentarán golpearlo al menos una vez.
Durante el camino puede encontrar bases de carga.
Para la oscuridad cuenta en el frente con un sensor ultrasónico que emitirá un pitido si detecta objetos y un panel de leds trasero que indica el nivel de carga y la detección de línea.

Test: https://leodanos.itch.io/luxoo

Una pequeña demostración:
https://www.youtube.com/watch?v=99zv-KX9dtQ
