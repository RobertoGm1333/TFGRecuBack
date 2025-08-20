CREATE DATABASE GatosDB;
USE GatosDB;

-- Tabla Usuario
CREATE TABLE Usuario (
    Id_Usuario INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Contraseña VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    Fecha_Registro DATETIME NOT NULL,
    Rol VARCHAR(20) NOT NULL DEFAULT 'usuario',
    Activo BIT NOT NULL DEFAULT 1
);

INSERT INTO Usuario (Nombre, Apellido, Contraseña, Email, Fecha_Registro, Rol, Activo)
VALUES 
('Roberto', 'Gomez', 'rob123', 'robadmin@gmail.com', SYSDATETIME(), 'admin', 1),
('Bigotes', 'Bigotes', 'Bigotes123', 'bigotescallejeroszgz@gmail.com', SYSDATETIME(), 'protectora', 1),
('Adala', 'Adala', 'Adala123', 'adalazaragoza@gmail.com', SYSDATETIME(), 'protectora', 1),
('Zarpa', 'Zarpa', 'Zarpa123', 'info@zarpa.org', SYSDATETIME(), 'protectora', 1),
('Gatolandia', 'Gatolandia', 'Gatolandia123', 'gatolandiazgz@gmail.com', SYSDATETIME(), 'protectora', 1),
('Zaragatos', 'Zaragatos', 'Zaragatos123', 'zaragatos@gmail.com', SYSDATETIME(), 'protectora', 1),
('4GatosyTu', '4GatosyTu', '4GatosyTu123', 'asociacion4gatosytu@gmail.com', SYSDATETIME(), 'protectora', 1);

-- Tabla Protectora
CREATE TABLE Protectora (
    Id_Protectora INT IDENTITY(1,1) PRIMARY KEY,
    Nombre_Protectora VARCHAR(100) NOT NULL,
    Direccion VARCHAR(100) NOT NULL,
    Ubicacion VARCHAR(5000) NOT NULL,
    Correo_Protectora VARCHAR(100) NOT NULL,
    Telefono_Protectora VARCHAR(15) NOT NULL,
    Pagina_Web VARCHAR(100) NOT NULL,
    Imagen_Protectora VARCHAR(5000) NOT NULL,
    Descripcion_Protectora VARCHAR(1000) NOT NULL,
    Descripcion_Protectora_En VARCHAR(1000) NOT NULL,
    Id_Usuario INT NOT NULL,
    FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id_Usuario)
);

INSERT INTO Protectora (Nombre_Protectora, Direccion, Ubicacion, Correo_Protectora, Telefono_Protectora, Pagina_Web, Imagen_Protectora, Descripcion_Protectora, Descripcion_Protectora_En, Id_Usuario)
VALUES 
('Bigotes Callejeros', 'Zaragoza', 'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d5962.117626099076!2d-0.8885988235248283!3d41.65447127938542!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0xd5914ea701a7919%3A0x1cd9cb8c1bef89d4!2sC.%20del%20Conde%20de%20Aranda%2C%2015%2C%20Casco%20Antiguo%2C%2050004%20Zaragoza!5e0!3m2!1ses!2ses!4v1747118352684!5m2!1ses!2ses', 'bigotescallejeroszgz@gmail.com', '123456789', 'https://bigotescallejeros.wordpress.com/', '/Images/protectoras/BigotesCallejeros.png', 'Somos una pequeña protectora de animales de Zaragoza que se encarga de velar por el bienestar de los gatos abandonados y darles la calidad de vida que merecen.', 'We are a small animal shelter in Zaragoza that takes care of the well-being of abandoned cats and gives them the quality of life they deserve.', 2),
('Adala', 'Zaragoza', 'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2982.4430154893716!2d-0.9094092235259463!3d41.62455468124995!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0xd596acc8696b2c1%3A0x81fd841dde9baa53!2sP.%C2%BA%20de%20los%20Infantes%20de%20Espa%C3%B1a%2C%2050012%2C%20Zaragoza!5e0!3m2!1ses!2ses!4v1747115917216!5m2!1ses!2ses','adalazaragoza@gmail.com', '654 616 982', 'https://adalazaragoza.com/', '/Images/protectoras/Adala.png', 'ADALA es una asociación sin ánimo de lucro cuyo objetivo es mejorar la vida de animales maltratados y/o abandonados. ADALA está compuesta por una red de casas de acogida que abren las puertas de su hogar a nuestros animales hasta que son adoptados. No contamos con refugio propio.', 'ADALA is a non-profit organization whose goal is to improve the lives of abused and/or abandoned animals. ADALA is made up of a network of foster homes that open the doors of their homes to our animals until they are adopted. We do not have our own shelter.', 3),
('Z.A.R.P.A.', 'Zaragoza', 'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2981.6737879318166!2d-0.8878358239275067!3d41.64118207126875!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0xd5914e0eb716f37%3A0xe5b13ba935b9bcd3!2sC.%20de%20Crist%C3%B3bal%20Col%C3%B3n%2C%206%2C%2050007%20Zaragoza!5e0!3m2!1ses!2ses!4v1747387190914!5m2!1ses!2ses', 'info@zarpa.org', '123456789', 'https://zarpa.org/', '/Images/protectoras/Zarpa.png', 'Zarpa es una asociación sin ánimo de lucro que se dedica a mejorar la vida de los animales abandonados o maltratados. Te invitamos a colaborar, hay muchas formas de hacerlo…', 'Zarpa is a non-profit organization dedicated to improving the lives of abandoned or mistreated animals. We invite you to collaborate, there are many ways to do so...', 4),
('Gatolandia', 'Zaragoza', 'https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d190783.12323243095!2d-0.877433!3d41.656038!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0xd5914ed1a21b48b%3A0xb215a2ea52d5adc7!2sAyuntamiento%20de%20Zaragoza!5e0!3m2!1ses!2sus!4v1747387576444!5m2!1ses!2sus', 'gatolandiazgz@gmail.com', '123456789', 'https://gatolandiazgz.wordpress.com/', '/Images/protectoras/Gatolandia.png', 'Somos una Asociación de Zaragoza sin ánimo de lucro, que rescata gatos abandonados, les curamos las heridas que hayan podido sufrir, difundimos su historia y fotos a través de redes sociales y les buscamos un buen hogar. No cobramos nada, solo nos interesa el bienestar del animal. Lo que nos gustaría es poder llegar a salvar muchos más de esos gatitos abandonados que muchas veces, por falta de dinero, no podemos atender. El importe se destinará íntegro a pagar los gastos veterinarios.', 'We are a non-profit association from Zaragoza that rescues abandoned cats, treats their injuries, spreads their stories and photos through social media, and looks for a good home for them. We dont charge anything, we are only interested in the well-being of the animal. What we would like is to save many more of those abandoned kittens that, many times, due to lack of money, we cant attend to. The funds will be fully allocated to cover veterinary expenses.', 5),
('Zaragatos', 'Zaragoza', 'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d5962.117626099076!2d-0.8885988235248283!3d41.65447127938542!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0xd5914ea701a7919%3A0x1cd9cb8c1bef89d4!2sC.%20del%20Conde%20de%20Aranda%2C%2015%2C%20Casco%20Antiguo%2C%2050004%20Zaragoza!5e0!3m2!1ses!2ses!4v1747118352684!5m2!1ses!2ses', ' zaragatos@gmail.com', '634510500', 'https://zaragatos.org/', '/Images/protectoras/Zaragatos.png', 'Una asociación sin ánimo de lucro dedicada a fomentar el cuidado y la adopción de gatos abandonados, así como concienciar sobre las consecuencias negativas de su abandono.', 'A non-profit association dedicated to promoting the care and adoption of abandoned cats, as well as raising awareness of the negative consequences of their abandonment.', 6),
('4GatosyTu', 'Huesca', 'https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d190783.12323243095!2d-0.877433!3d41.656038!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0xd5914ed1a21b48b%3A0xb215a2ea52d5adc7!2sAyuntamiento%20de%20Zaragoza!5e0!3m2!1ses!2sus!4v1747387576444!5m2!1ses!2sus', 'asociacion4gatosytu@gmail.com', '634717501', 'https://asociacion4gatosytu.es.tl/Portada.htm', '/Images/protectoras/4GatosyTu.png', 'Somos un grupo de voluntarios, que desde 2007 formamos una asociación sin ánimo de lucro, con el fin de mejorar la calidad de vida de los gatos, principalmente de la ciudad de Zaragoza.', 'We are a group of volunteers, who since 2007 have formed a non-profit association, in order to improve the quality of life of cats, mainly from the city of Zaragoza.', 7);

-- Tabla Gato
CREATE TABLE Gato (
    Id_Gato INT IDENTITY(1,1) PRIMARY KEY,
    Id_Protectora INT NOT NULL,
    Nombre_Gato VARCHAR(100) NOT NULL,
    Raza VARCHAR(100) NOT NULL,
    Edad INT NOT NULL,
    Esterilizado BIT NOT NULL,
    Sexo VARCHAR(10) NOT NULL,
    Descripcion_Gato VARCHAR(1000) NOT NULL,
    Descripcion_Gato_En VARCHAR(1000) NOT NULL,
    Imagen_Gato VARCHAR(5000),
    Visible BIT NOT NULL DEFAULT 1,
    FOREIGN KEY (Id_Protectora) REFERENCES Protectora(Id_Protectora)
);

INSERT INTO Gato (Id_Protectora, Nombre_Gato, Raza, Edad, Esterilizado, Sexo, Descripcion_Gato, Descripcion_Gato_En, Imagen_Gato)
VALUES 
(2, 'Widow', 'Pardo', 4, 0, 'Macho', 'Al haber vivido mucho tiempo en la calle es algo desconfiado. Necesita que le den su espacio para no sentirse amenazado.', 'Having lived on the streets for a long time, he is somewhat distrustful. He needs his space to not feel threatened.', '/Images/gatos/Widow.png'),
(2, 'Claudia', 'Gris', 1, 1, 'Hembra', 'Tiene el típico carácter de un gato, cercana pero cuando ella quiere.', 'She has the typical character of a cat, affectionate but only when she wants to.', '/Images/gatos/Claudia.png'),
(2, 'Sira', 'Pardo', 1, 1, 'Hembra', 'Es una gata que se encontró en un polígono y al principio es un poco tímida pero con un poco de paciencia es muy cariñosa.', 'She is a cat that was found in an industrial area, initially a little shy, but with patience, she is very affectionate.', '/Images/gatos/Sira.png'),
(2, 'Milu', 'Tuxedo', 7, 1, 'Macho', 'Es muy chico bueno en traje.', 'He is a very good boy in a tuxedo.', '/Images/gatos/Milu.png'),
(2, 'Lupita', 'Blanco', 1, 1, 'Hembra', 'Necesita una familia con paciencia, tiene muchos miedos y necesita tiempo para volver a confiar.', 'She needs a family with patience, has many fears, and needs time to trust again.', '/Images/gatos/Lupita.png'),
(2, 'Charlotte', 'Tuxedo', 1, 1, 'Hembra', 'Es muy buena y un amor.', 'She is very good and a sweetheart.', '/Images/gatos/Charlotte.png'),
(1, 'Martita', 'Naranja y negro', 3, 1, 'Hembra', 'Es muy sociable, tranquila y se adapta a otros gatos.', 'She is very sociable, calm, and adapts well to other cats.', '/Images/gatos/Martita.png'),
(1, 'Tito', 'Pardo', 1, 1, 'Macho', 'Hubo que amputarle el rabo por una infección pero no le impide jugar y dar cariño.', 'We had to have his tail amputated due to an infection, but it doesnt stop him from playing and giving affection.', '/Images/gatos/Tito.png'),
(1, 'Melocotón', 'Naranja y negro', 2, 1, 'Macho', 'Necesita compañía y se lleva genial con otros gatos y personas.', 'He needs companionship and gets along very well with other cats and people.', '/Images/gatos/Melocoton.png'),
(1, 'Lucas', 'Pardo', 1, 1, 'Macho', 'Necesita una adopción estable, alguien que realmente ame a los animales y tenga paciencia para respetar su espacio, y que poco a poco se vaya acercando.', 'He needs a stable adoption, someone who truly loves animals, has patience to respect his space, and slowly gets closer.', '/Images/gatos/Lucas.png'),
(1, 'Chloe', 'Blanco y pardo', 1, 1, 'Hembra', 'Necesita una adopción estable, alguien que realmente ame a los animales y tenga paciencia para respetar su espacio, y que poco a poco se vaya acercando.', 'She needs a stable adoption, someone who truly loves animals, has patience to respect her space, and slowly gets closer.', '/Images/gatos/Chloe.png'),
(1, 'Carter', 'Blanco y pardo', 1, 1, 'Macho', 'Es un cachorrito muy juguetón al que le encanta socializar y pasar el rato con todo el mundo.', 'He is a very playful puppy who loves to socialize and spend time with everyone.', '/Images/gatos/Carter.png'),
(5, 'Simon', 'Siames', 4, 1, 'Macho', 'Es un gatico muy inquieto y curioso. Es muy cariñoso y le encanta estar encima de las personas.', 'He is a very restless and curious cat. He is very affectionate and loves to be on top of people.', '/Images/gatos/Simon.png'),
(5, 'Maria', 'Negro', 4, 1, 'Hembra', 'A María la rescatamos en un solar abandonado. Es una gatica algo asustadiza al principio pero muy cariñosa, dulce y buena.', 'We rescued Maria from an abandoned lot. She is a bit scared at first but very affectionate, sweet, and good.', '/Images/gatos/Maria.png'),
(5, 'Elton', 'Naranja y blanco', 2, 1, 'Macho', 'Vino asustado y enfermo de una zona muy peligrosa de la ciudad, pero ahora que ha recuperado fuerzas es muy juguetón, cariñoso y enérgico.', 'He came scared and sick from a very dangerous area of the city, but now that he has regained strength, he is very playful, affectionate, and energetic.', '/Images/gatos/Elton.png'),
(5, 'Bimba', 'Naranja y blanco', 2, 1, 'Hembra', 'Bimba es una gata tranquila la mayoria del tiempo aunque también le gusta jugar, es cariñosa pero a demanda, ósea, cuando quiere mimos ella los pide.', 'Bimba is a calm cat most of the time, but she also likes to play. She is affectionate, but only when she wants, so she asks for affection when she desires it.', '/Images/gatos/Bimba.png'),
(5, 'Rocky', 'Blanco y negro', 1, 1, 'Macho', 'Rocky es un gatito muy cariñoso y sociable. Se lleva bien tanto con humanos como con otros gatos. Le gusta subir a las alturas y jugar con juguetitos pequeños y plumas.', 'Rocky is a very affectionate and sociable kitten. He gets along well with both humans and other cats. He loves climbing to high places and playing with small toys and feathers.', '/Images/gatos/Rocky.png'),
(5, 'Valentina', 'Blanco y negro', 1, 1, 'Hembra', 'Valentina es una gatita listísima, valiente, muy juguetona, cariñosa y buena. Le gusta echarse a dormir sobre tu regazo cuando te sientas, ronronea y hace masajes.', 'Valentina is a very smart, brave, playful, affectionate, and good kitten. She loves to nap on your lap when you sit down, purring and giving massages.', '/Images/gatos/Valentina.png'),
(5, 'Wallie', 'Pardo', 5, 1, 'Macho', 'En su casa de acogida ha resultado ser un gato muy tranquilo y algo tímido e independiente. Se deja acariciar cuando el quiere.', 'In his foster home, he turned out to be a very calm and slightly shy, independent cat. He lets himself be petted when he wants to.', '/Images/gatos/Wallie.png'),
(5, 'Leo', 'Blanco y pardo', 1, 1, 'Macho', 'A Leo le oyeron maullar unos adoptantes nuestros en la calle y literalmente se les echó a los brazos. En su casa de acogida ha resultado ser un gato superbueno, cariñoso, inteligente y sociable.', 'Leo was heard meowing by some of our adopters on the street and literally jumped into their arms. In his foster home, he turned out to be a super good, affectionate, intelligent, and sociable cat.', '/Images/gatos/Leo.png'),
(5, 'Suyai', 'Blanco y negro', 2, 1, 'Hembra', 'Está gatita, necesita una persona que ya tenga experiencia con gatos, necesita que le den su espacio, ella sola se acerca, se tumba contigo en el sofá o en la cama, se restriega en las piernas, te pide comida, se deja tocar pero no en exceso.', 'This little cat needs someone who already has experience with cats, she needs her space, but she approaches by herself, lays down with you on the sofa or bed, rubs against your legs, asks for food, and lets you touch her but not excessively.', '/Images/gatos/Suyai.png'),
(5, 'Jezabel', 'Negro', 3, 1, 'Hembra', 'Ella es muy sociable con humanos, y con gatos se adapta ; le encanta jugar con pelotas, y es muy pedigüeña de comida, le da igual la que sea, te permite acariciarla sin problema y duerme cerca de ti sus siestas.', 'She is very sociable with humans and adapts to other cats; she loves playing with balls and is very food-demanding, no matter what it is. She lets you pet her without any problem and sleeps near you for her naps.', '/Images/gatos/Jezabel.png'),
(5, 'Gatica', 'Tricolor', 2, 1, 'Hembra', 'Gatica es , como se dice, una «gata 10». Es tranquila, aunque tiene sus momentos de juego, muy buena y sociable. Respeta los espacios de las personas y le gusta recibir a los invitados en casa. Es una gata que lo tiene todo.', 'Gatica is, as they say, a "10/10 cat." She is calm, although she has moments of play, very good and sociable. She respects peoples spaces and likes receiving guests at home. She is a cat that has it all.', '/Images/gatos/Gatica.png'),
(5, 'Gypsie', 'Naranja y negro', 3, 1, 'Hembra', 'Es suuuuper juguetona, le encantan los ratoncitos, tapones de las orejas y cualquier objeto que pueda hacer mover ella por el suelo.Es suuuper super cariñosa, le encanta dormir acompañada y a la que empiezas a acariciarla empieza a ronronear que parece un motor', 'She is super playful, loves little mice, earplugs, and any object she can move around the floor. She is super affectionate, loves to sleep with others, and as soon as you start petting her, she starts purring like an engine.', '/Images/gatos/Gypsie.png'),
(5, 'Betania', 'Negro', 2, 1, 'Hembra', 'Viene de una camada de gatitos donde todos son super cariñosos, juguetones y sociables, lamentablemente sus dueños originales no se podían hacer cargo de ella y ahora está esperando a un hogar que la cuide y juegue con ella', 'She comes from a litter of kittens where all of them are super affectionate, playful, and sociable. Unfortunately, her original owners couldnt take care of her, and now she is waiting for a home that will care for and play with her.', '/Images/gatos/Betania.png'),
(6, 'Nikky', 'Tuxedo', 3, 1, 'Hembra', 'Es una gatita muy cariñosa que le encanta jugar con su caña y rodar en el suelo haciendo la croqueta todo el día.', 'She is a very affectionate kitten who loves playing with her stick and rolling on the floor doing the croquette all day long.', '/Images/gatos/Nikky.png'),
(6, 'Zúa', 'Naranja', 2, 1, 'Hembra', 'Es guapa, guapa, guapa y mimosa, mimosa, mimosa. De pelo semilargo y figura esbelta,jajaja. Está esterilizada, vacunada y dispuesta a irse donde le den bien de comer.', 'She is beautiful, beautiful, beautiful, and affectionate, affectionate, affectionate. With semi-long fur and a slender figure, haha. She is sterilized, vaccinated, and ready to go to a home where they treat her well.', '/Images/gatos/Zua.png'),
(6, 'Café', 'Negro', 4, 1, 'Macho', 'Es super bueno y cariñoso, siempre te busca para rascarse contra ti y exigir atención a cambio de muchos ronroneos', 'He is super good and affectionate, always looking for you to scratch him and demand attention in exchange for a lot of purring.', '/Images/gatos/Cafe.png'),
(6, 'Nati', 'Blanco y pardo', 4, 1, 'Hembra', 'Es un amor de gata, le gusta tomar siestas al sol cerca de una ventana aunque suele preferir los descansos más largos acurrucada junto a su dueño', 'She is a lovely cat, loves taking naps in the sun near a window, although she usually prefers longer naps cuddled up next to her owner.', '/Images/gatos/Nati.png'),
(3, 'Amelio', 'Siames', 9, 1, 'Macho', 'Amelio es todo un galán, es guapo y estamos seguros de que él lo sabe.', 'He is a real gentleman, good-looking, and we are sure he knows it.', '/Images/gatos/Amelio.png'),
(3, 'Dorado', 'Naranja', 7, 0, 'Macho', 'Dorado ha tenido muy mala vida. Ya es hora de que le cambie la suerte, y pueda disfrutar de un hogar donde le cuiden y quieran. Ahora está descubriendo los mimos, las caricias y las siestas al sol, y le encantan. Pese a todo lo que ha pasado, es un gato muy cariñoso con las personas. Sin embargo, le está costando estar con otros gatos.', 'Dorado has had a very tough life. It is time for his luck to change, and he can enjoy a home where he is cared for and loved. He is now discovering the joys of cuddles, caresses, and sunbathing, and he loves it. Despite everything he has been through, he is a very affectionate cat with people. However, he is struggling to get along with other cats.', '/Images/gatos/Dorado.png'),
(3, 'Panchi', 'Tuxedo', 1, 1, 'Hembra', 'Panchi es un sol. Es una gatita cariñosa, mimosa y juguetona. Con ella entrará en tu casa la alegría y la diversión. Tendrás una compañera perfecta de sofá y siestas, y también de juegos y enredos.', 'Panchi is a sunshine. She is a sweet, affectionate, and playful kitten. With her, joy and fun will enter your home. You will have a perfect sofa companion for naps and a playful partner for games and fun.', '/Images/gatos/Panchi.png'),
(3, 'Canelon', 'Naranja', 1, 1, 'Macho', 'Desde el principio ha demostrado que es cariñoso y bueno. Es un gato tranquilo, dormilón y le gusta mucho el contacto. Le encanta dormir pegadito a su humano. Pero también es divertido, juguetón y con el puntito justo de locura que tienen los gatitos jóvenes.', 'From the beginning, he has shown to be affectionate and good. He is a calm, sleepy cat who loves contact. He enjoys sleeping close to his human. But he is also fun, playful, and with just the right amount of craziness that young kittens have.', '/Images/gatos/Canelon.png'),
(3, 'Sol', 'Carey', 2, 1, 'Hembra', 'Nos encanta Sol, y si la conoces, también te atrapará. Las leyendas dicen que traen buena suerte, y, sea o no verdad, estamos seguros de que Sol traerá felicidad a la casa a la que vaya.', 'We love Sol, and if you meet her, you will love her too. Legends say they bring good luck, and whether its true or not, we are sure that Sol will bring happiness to the home she goes to.', '/Images/gatos/Sol.png'),
(4, 'Tina', 'Tuxedo', 6, 1, 'Hembra', 'Es un amor de gata. Le encanta descansar cerca de la ventana y pasar el tiempo mirando a las palomas de afuera. Es algo distante pero cuando quiere se te pega mucho para que le des mimos.', 'She is a loving cat. She loves resting by the window and spending time watching the pigeons outside. She is somewhat distant, but when she wants to, she gets very close to you so you can pet her.', '/Images/gatos/Tina.png'),
(4, 'Judia', 'Tricolor', 2, 1, 'Hembra', 'Esta gatita, necesita una persona que ya tenga experiencia con gatos, necesita que le den su espacio, ella sola se acerca, se tumba contigo en el sofá o en la cama, se restriega en las piernas, te pide comida, se deja tocar pero no en exceso.', 'This little cat needs someone who already has experience with cats, she needs her space, but she approaches by herself, lays down with you on the sofa or bed, rubs against your legs, asks for food, and lets you touch her but not excessively.', '/Images/gatos/Judia.png'),
(4, 'Milka', 'Blanco y negro', 1, 1, 'Hembra', 'Viene de una camada de gatitos donde todos son super cariñosos, juguetones y sociables, lamentablemente sus dueños originales no se podían hacer cargo de ella y ahora está esperando a un hogar que la cuide y juegue con ella', 'Milka is from a litter of kittens where all of them are very affectionate, playful, and sociable. Unfortunately, her original owners couldnt take care of her, and now she is waiting for a home that will care for and play with her.', '/Images/gatos/Milka.png'),
(4, 'Lenteja', 'Pardo', 4, 1, 'Hembra', 'Lenteja es una gata tranquila la mayoria del tiempo aunque también le gusta jugar, es cariñosa pero a demanda, ósea, cuando quiere mimos ella los pide.', 'Lenteja is a calm cat most of the time, but she also likes to play. She is affectionate, but only when she wants to. So, when she wants affection, she asks for it.', '/Images/gatos/Lenteja.png'),
(4, 'Puri', 'Blanco y pardo', 2, 1, 'Hembra', 'Puri fue abandonada cuando era tan solo una gatita por su anterior familia. Ahora solo busca algo de cariño y atención en su nuevo hogar.', 'Puri was abandoned when she was just a kitten by her previous family. Now, she is only looking for some love and attention in her new home.', '/Images/gatos/Puri.png'),
(4, 'Marcos', 'Blanco y negro', 1, 1, 'Macho', 'Marcos es super bueno y cariñoso, siempre te busca para rascarse contra ti y exigir atención a cambio de muchos ronroneos', 'Marcos is super good and affectionate, always looking for you to scratch him and demand attention in exchange for a lot of purring.', '/Images/gatos/Marcos.png');

-- Tabla Deseados
CREATE TABLE Deseados (
    Id_Deseado INT IDENTITY(1,1) PRIMARY KEY,
    Id_Usuario INT NOT NULL,
    Id_Gato INT NOT NULL,
    Fecha_Deseado DATETIME NOT NULL,
    FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id_Usuario) ON DELETE CASCADE,
    FOREIGN KEY (Id_Gato) REFERENCES Gato(Id_Gato) ON DELETE CASCADE
);

INSERT INTO Deseados (Id_Usuario, Id_Gato, Fecha_Deseado)
VALUES
(1, 2, SYSDATETIME()),
(1, 1, SYSDATETIME());

-- NUEVA Tabla SolicitudAdopcionExtendida (reemplazo completo)
CREATE TABLE SolicitudAdopcion (
    Id_Solicitud INT IDENTITY(1,1) PRIMARY KEY,
    Id_Usuario INT NOT NULL,
    Id_Gato INT NOT NULL,
    Fecha_Solicitud DATETIME NOT NULL DEFAULT GETDATE(),
    Estado VARCHAR(20) NOT NULL DEFAULT 'pendiente',
    NombreCompleto VARCHAR(100),
    Edad INT,
    Direccion VARCHAR(255),
    DNI VARCHAR(20),
    Telefono VARCHAR(20),
    Email VARCHAR(100),
    TipoVivienda VARCHAR(50),
    PropiedadAlquiler VARCHAR(50),
    PermiteAnimales BIT,
    NumeroPersonas INT,
    HayNinos BIT,
    EdadesNinos VARCHAR(100),
    ExperienciaGatos BIT,
    TieneOtrosAnimales BIT,
    CortarUnas BIT,
    AnimalesVacunadosEsterilizados BIT,
    HistorialMascotas VARCHAR(1000),
    MotivacionAdopcion VARCHAR(1000),
    ProblemasComportamiento VARCHAR(1000),
    EnfermedadesCostosas VARCHAR(1000),
    Vacaciones VARCHAR(1000),
    SeguimientoPostAdopcion BIT,
    VisitaHogar BIT,
    Comentario_Protectora VARCHAR(1000),
    FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id_Usuario),
    FOREIGN KEY (Id_Gato) REFERENCES Gato(Id_Gato)
);

-- NUEVA Tabla Adopcion (reemplazo completo)
CREATE TABLE Adopcion (
    Id_Adopcion INT IDENTITY(1,1) PRIMARY KEY,
    Id_Protectora INT NOT NULL,
    Id_Gato INT NOT NULL,
    Fecha_Adopcion DATETIME NOT NULL DEFAULT GETDATE(),
    OrigenWeb  BIT NOT NULL DEFAULT 0,
    Telefono_Adoptante VARCHAR(20),
    Observaciones VARCHAR(1000)  NULL,
    FOREIGN KEY (Id_Protectora) REFERENCES Protectora(Id_Protectora),
    FOREIGN KEY (Id_Gato) REFERENCES Gato(Id_Gato)
);

