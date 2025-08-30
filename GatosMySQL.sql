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
(4, 'Marcos', 'Blanco y negro', 1, 1, 'Macho', 'Marcos es super bueno y cariñoso, siempre te busca para rascarse contra ti y exigir atención a cambio de muchos ronroneos', 'Marcos is super good and affectionate, always looking for you to scratch him and demand attention in exchange for a lot of purring.', '/Images/gatos/Marcos.png'),
(2, 'Ravel', 'Pardo', 3, 1, 'Macho', 'Explorador tranquilo que se pasea por la casa con curiosidad. Le gusta observar desde estantes altos y, cuando se siente seguro, se acurruca a tu lado para una siesta larga.', 'A calm explorer who roams the house with curiosity. He likes to perch on high shelves and, once he feels safe, curls up beside you for a long nap.', '/Images/gatos/Ravel.png'),
(3, 'Sienna', 'Pardo', 2, 0, 'Hembra', 'Al principio puede parecer reservada, pero responde muy bien a una rutina estable. Disfruta los rascadores de cartón y los juegos cortos con caña.', 'She may seem reserved at first, but responds well to a steady routine. She enjoys cardboard scratchers and short wand-toy play sessions.', '/Images/gatos/Sienna.png'),
(4, 'Tundra', 'Pardo', 4, 1, 'Macho', 'De mirada noble y paso sigiloso. Prefiere espacios tranquilos, pero se anima mucho cuando hay premios blanditos de por medio.', 'Noble gaze and stealthy steps. Prefers quiet spaces, but gets lively when soft treats are involved.', '/Images/gatos/Tundra.png'),
(5, 'Melva', 'Pardo', 1, 1, 'Hembra', 'Cachorrita vivaz que aprende rápido las rutinas del hogar. Le encanta perseguir sombras y dormirse sobre una manta tibia.', 'Lively kitten who quickly learns home routines. Loves chasing shadows and falling asleep on a warm blanket.', '/Images/gatos/Melva.png'),
(6, 'Bosco', 'Pardo', 5, 0, 'Macho', 'Gran compañero de sofá que busca contacto sin agobiar. Se entiende bien con otros gatos tranquilos y respeta los tiempos.', 'A great couch companion who seeks contact without overwhelming. Gets along with calm cats and respects boundaries.', '/Images/gatos/Bosco.png'),
(1, 'Canela', 'Pardo', 3, 1, 'Hembra', 'Muy observadora: estudia cada rincón antes de acercarse. Cuando confía, pide caricias con suaves cabezazos.', 'Very observant: she studies every corner before approaching. Once she trusts you, she asks for pets with gentle head bumps.', '/Images/gatos/Canela.png'),
(5, 'Pardo', 'Pardo', 6, 1, 'Macho', 'Nombre peculiar para un pelaje clásico. Tranquilo, agradece rutinas predecibles y un lugar alto desde donde mirar la casa.', 'A quirky name for a classic coat. Calm, he appreciates predictable routines and a high spot to watch over the home.', '/Images/gatos/Pardo.png'),
(2, 'Brisa', 'Gris', 2, 1, 'Hembra', 'Sutil y elegante, se mueve en silencio por la casa. Le gustan los juguetes de cuerda y dormirse junto a la ventana.', 'Subtle and elegant, she moves quietly around the house. Likes string toys and napping by the window.', '/Images/gatos/Brisa.png'),
(3, 'Mercurio', 'Gris', 4, 1, 'Macho', 'Gran observador, sigue a su humano de habitación en habitación. Agradece sesiones cortas de cepillado.', 'A great observer who follows his human from room to room. Appreciates short brushing sessions.', '/Images/gatos/Mercurio.png'),
(4, 'Lluvia', 'Gris', 1, 0, 'Hembra', 'Timidilla al principio, pero responde muy bien a un entorno calmado. En poco tiempo ronronea al primer contacto.', 'A bit shy at first, but thrives in a calm environment. Soon purrs at the first touch.', '/Images/gatos/Lluvia.png'),
(5, 'Cromo', 'Gris', 5, 1, 'Macho', 'Le encanta vigilar desde un rascador alto y hacer pequeñas patrullas nocturnas. Es sociable con visitas tranquilas.', 'Loves to keep watch from a tall scratcher and do small night patrols. Sociable with calm visitors.', '/Images/gatos/Cromo.png'),
(6, 'Tiza', 'Gris', 3, 0, 'Hembra', 'Disfruta las cajas y los escondites; perfecta para hogares con rincones. Pide juego a ratitos y luego descansa profundo.', 'Enjoys boxes and hideouts; perfect for homes with nooks. Asks for play in bursts and then rests deeply.', '/Images/gatos/Tiza.png'),
(1, 'Argos', 'Gris', 6, 1, 'Macho', 'Sereno y cariñoso, se adapta bien a rutinas estables. Ideal para quien busque un compañero sosegado.', 'Serene and affectionate, adapts well to stable routines. Ideal for someone seeking a calm companion.', '/Images/gatos/Argos.png'),
(5, 'Nimbus', 'Gris', 2, 1, 'Macho', 'Pequeño torbellino de juego que luego cae rendido. Le encanta perseguir bolitas por el pasillo.', 'A small whirlwind of play who then crashes out. Loves chasing little balls down the hallway.', '/Images/gatos/Nimbus.png'),
(2, 'Frack', 'Tuxedo', 3, 1, 'Macho', 'Elegante de traje y muy simpático. Se sienta cerca como si “conversara” y responde a su nombre cuando hay premios.', 'Dapper in a tux and very friendly. Sits nearby as if to “chat” and responds to his name when treats appear.', '/Images/gatos/Frack.png'),
(3, 'Greta', 'Tuxedo', 2, 0, 'Hembra', 'Lista y juguetona, aprende trucos con facilidad. Le encanta el láser y las cañas con plumas.', 'Smart and playful, learns tricks easily. Loves laser pointers and feather wands.', '/Images/gatos/Greta.png'),
(4, 'Picasso', 'Tuxedo', 5, 1, 'Macho', 'Tiene un maullido suave y una mirada calmada. Le gusta dormir a tus pies por las noches.', 'Soft meow and calm gaze. Likes to sleep at your feet at night.', '/Images/gatos/Picasso.png'),
(5, 'Menta', 'Tuxedo', 1, 1, 'Hembra', 'Cachorra despierta que pide juego a menudo. Se calma rápido si la cubres con una manta suave.', 'Alert kitten who often asks to play. Calms quickly if covered with a soft blanket.', '/Images/gatos/Menta.png'),
(6, 'Héctor', 'Tuxedo', 6, 1, 'Macho', 'Leal y cariñoso, sigue rutinas con puntualidad. Agradece cepillados regulares para mantener su pelaje impecable.', 'Loyal and affectionate, he follows routines punctually. Appreciates regular brushing to keep his coat pristine.', '/Images/gatos/Hector.png'),
(1, 'Dalia', 'Tuxedo', 4, 0, 'Hembra', 'Coqueta y sociable, se acerca para recibir a las visitas. Le gustan los rascadores de sisal.', 'Charming and sociable, she greets visitors. Enjoys sisal scratchers.', '/Images/gatos/Dalia.png'),
(5, 'Onyx', 'Tuxedo', 3, 1, 'Macho', 'Curioso y prudente a la vez: explora y vuelve a tu lado para pedir mimos. Perfecto para casas con ritmo calmado.', 'Curious yet cautious: explores then returns for cuddles. Perfect for calm-paced homes.', '/Images/gatos/Onyx.png'),
(2, 'Perla', 'Blanco', 2, 1, 'Hembra', 'Muy limpia y delicada con sus movimientos. Busca rayitos de sol para tumbarse y calentarse.', 'Very tidy and delicate in her movements. Seeks sunbeams to bask and warm up.', '/Images/gatos/Perla.png'),
(3, 'Alaska', 'Blanco', 5, 0, 'Macho', 'Gato sereno que agradece la compañía tranquila. Le gusta que le hablen suave mientras lo cepillan.', 'A serene cat who appreciates calm company. Likes being spoken to softly while being brushed.', '/Images/gatos/Alaska.png'),
(4, 'Nieve', 'Blanco', 1, 1, 'Hembra', 'Cachorra curiosa que investiga cada bolsa y cajón. Se duerme sobre cojines blanditos.', 'Curious kitten who investigates every bag and drawer. Falls asleep on soft cushions.', '/Images/gatos/Nieve.png'),
(5, 'Loto', 'Blanco', 3, 1, 'Macho', 'Muy afectuoso, busca contacto con la frente. Se entiende bien con niños respetuosos.', 'Very affectionate, seeks forehead contact. Gets along with respectful children.', '/Images/gatos/Loto.png'),
(6, 'Lunares', 'Blanco', 4, 1, 'Hembra', 'De carácter dulce y constante. Le gustan las rutinas de juego y descanso bien marcadas.', 'Sweet and consistent temperament. Likes well-marked play and rest routines.', '/Images/gatos/Lunares.png'),
(1, 'Armiño', 'Blanco', 6, 0, 'Macho', 'Se acomoda junto a su persona favorita y vigila el entorno con calma. Adora las mantas polares.', 'Settles next to his favorite person and calmly watches the surroundings. Loves fleece blankets.', '/Images/gatos/Armino.png'),
(5, 'Quilla', 'Blanco', 2, 1, 'Hembra', 'Activa pero equilibrada: juega con energía y luego descansa profundamente. Ideal para hogares luminosos.', 'Active yet balanced: plays energetically then rests deeply. Ideal for bright homes.', '/Images/gatos/Quilla.png'),
(2, 'Fakir', 'Negro', 3, 1, 'Macho', 'Elegante y silencioso, aparecen sus mejores ronroneos por la tarde. Aprovecha cada rayo de sol.', 'Elegant and quiet; his best purrs come in the afternoon. Takes advantage of every sunbeam.', '/Images/gatos/Fakir.png'),
(3, 'Mora', 'Negro', 2, 0, 'Hembra', 'Tiene un brillo precioso en el pelaje y adora los rascadores de cartón. Se acerca con confianza si la llamas suave.', 'Her coat shines beautifully and she loves cardboard scratchers. Comes confidently when you call softly.', '/Images/gatos/Mora.png'),
(4, 'Brea', 'Negro', 6, 1, 'Hembra', 'Tranquila, paciente y muy compañera. Se acomoda cerca para escuchar podcasts contigo.', 'Calm, patient, and very companionable. Settles nearby to “listen” to podcasts with you.', '/Images/gatos/Brea.png'),
(5, 'Sable', 'Negro', 4, 1, 'Macho', 'De carácter noble, tolera bien las visitas educadas. Le gustan los juguetes con catnip.', 'Noble temperament; tolerates polite visitors well. Enjoys catnip toys.', '/Images/gatos/Sable.png'),
(6, 'Noctis', 'Negro', 1, 1, 'Macho', 'Cachorro inquieto que aprende rápido. Perfecto para jugar en sesiones cortas y frecuentes.', 'Restless kitten who learns quickly. Perfect for short, frequent play sessions.', '/Images/gatos/Noctis.png'),
(1, 'Onice', 'Negro', 5, 0, 'Hembra', 'Independiente, pero agradece un regazo cálido cuando cae la tarde. Muy limpia con su arenero.', 'Independent, but appreciates a warm lap in the evening. Very tidy with her litter box.', '/Images/gatos/Onice.png'),
(5, 'Cenit', 'Negro', 3, 1, 'Macho', 'Sociable y curioso; le encantan los túneles de juego. Duerme plácidamente tras cada sesión.', 'Sociable and curious; loves play tunnels. Sleeps soundly after each session.', '/Images/gatos/Cenit.png'),
(2, 'Coral', 'Naranja', 2, 1, 'Hembra', 'Brillante y alegre, siempre trae buen ánimo. Le encanta la caza de pelotitas.', 'Bright and cheerful, always lifts the mood. Loves chasing little balls.', '/Images/gatos/Coral.png'),
(3, 'Brandy', 'Naranja', 4, 1, 'Macho', 'Dulce y pegajoso, te sigue por la casa para echarse cerca. Pide mimos con patitas suaves.', 'Sweet and clingy, follows you around to lie nearby. Asks for cuddles with gentle paws.', '/Images/gatos/Brandy.png'),
(4, 'Siroco', 'Naranja', 3, 0, 'Macho', 'Juguetón nato con energía moderada. Ideal para familias que disfruten juegos diarios.', 'Born playful with moderate energy. Ideal for families who enjoy daily play.', '/Images/gatos/Siroco.png'),
(5, 'Duna', 'Naranja', 1, 1, 'Hembra', 'Cachorrita curiosa, aprende rápido a usar rascadores. Se calma con caricias lentas.', 'Curious kitten, quickly learns to use scratchers. Calms with slow pets.', '/Images/gatos/Duna.png'),
(6, 'Polen', 'Naranja', 5, 1, 'Macho', 'Gran comedor de premios, coopera para cepillado y limpieza. Le encanta el sol de la mañana.', 'Treat enthusiast; cooperates for grooming and cleaning. Loves the morning sun.', '/Images/gatos/Polen.png'),
(1, 'Folclor', 'Naranja', 6, 0, 'Macho', 'Sosegado y observador, se acomoda en alfombras mullidas. Busca compañía sin invadir.', 'Calm and observant, settles on plush rugs. Seeks company without crowding.', '/Images/gatos/Folclor.png'),
(5, 'Monarca', 'Naranja', 2, 1, 'Hembra', 'Activo pero equilibrado, alterna juegos cortos con siestas largas. Ideal para pisos con luz.', 'Active yet balanced, alternates short play with long naps. Ideal for sunlit apartments.', '/Images/gatos/Monarca.png'),
(2, 'Nora', 'Naranja y blanco', 1, 1, 'Hembra', 'Muy mimosa, se estira a tu lado para pedir caricias. Perfecta para hogares tranquilos.', 'Very cuddly; stretches out beside you for pets. Perfect for calm homes.', '/Images/gatos/Nora.png'),
(3, 'Trasto', 'Naranja y blanco', 3, 0, 'Macho', 'Gracioso y bonachón, persigue plumas y descansa en cajas. Agradece compañía cercana.', 'Funny and good-natured, chases feathers and rests in boxes. Appreciates close company.', '/Images/gatos/Trasto.png'),
(4, 'Calíope', 'Naranja y blanco', 4, 1, 'Hembra', 'Elegante y serena. Le gusta dormir en alto y observar todo con calma.', 'Elegant and serene. Likes to sleep up high and watch everything calmly.', '/Images/gatos/Caliope.png'),
(5, 'Mistral', 'Naranja y blanco', 2, 1, 'Macho', 'Juguetón con cuerditas y plumas. Se regula bien: juego, agua y siesta.', 'Playful with strings and feathers. Self-regulates well: play, water, nap.', '/Images/gatos/Mistral.png'),
(6, 'Aruma', 'Naranja y blanco', 5, 1, 'Hembra', 'Muy compañera, disfruta estar cerca mientras trabajas. Se duerme al sonido del teclado.', 'A true companion; likes being near while you work. Falls asleep to the sound of typing.', '/Images/gatos/Aruma.png'),
(1, 'Canelo', 'Naranja y blanco', 6, 0, 'Macho', 'Buenazo y paciente; perfecto para familias tranquilas. Le gustan los rascadores altos.', 'Good-natured and patient; perfect for calm families. Likes tall scratchers.', '/Images/gatos/Canelo.png'),
(5, 'Piña', 'Naranja y blanco', 3, 1, 'Hembra', 'Le encantan los juegos de esconder y buscar. Tras jugar, busca tu regazo.', 'Loves hide-and-seek style games. After play, seeks your lap.', '/Images/gatos/Pina.png'),
(2, 'Mosaic', 'Carey', 3, 1, 'Hembra', 'Personalidad curiosa y valiente. Se acerca despacio y pide mimos cuando confía.', 'Curious and brave personality. Approaches slowly and asks for pets once she trusts you.', '/Images/gatos/Mosaic.png'),
(3, 'Gala', 'Carey', 2, 0, 'Hembra', 'Juguetona y habilidosa con la caña; da pequeños saltos acrobáticos. Luego duerme profundamente.', 'Playful and skilled with the wand; does small acrobatic jumps. Then sleeps deeply.', '/Images/gatos/Gala.png'),
(4, 'Tritón', 'Carey', 5, 1, 'Macho', 'Aunque poco común en machos carey, es calmado y tierno. Agradece rutinas previsibles.', 'Though rare for male torties, he’s calm and tender. Appreciates predictable routines.', '/Images/gatos/Triton.png'),
(5, 'Nadia', 'Carey', 1, 1, 'Hembra', 'Cachorra con carácter dulce y seguro. Se adapta bien a pisos con ritmo suave.', 'Kitten with a sweet, confident character. Adapts well to soft-paced apartments.', '/Images/gatos/Nadia.png'),
(6, 'Bruma', 'Carey', 6, 1, 'Hembra', 'Disfruta los sillones al sol y las tardes tranquilas. Busca contacto con suavidad.', 'Enjoys sunny armchairs and quiet afternoons. Seeks gentle contact.', '/Images/gatos/Bruma.png'),
(1, 'Laka', 'Carey', 4, 0, 'Hembra', 'Sociable, se acerca a oler y saludar con un maullido suave. Ideal para hogares calmados.', 'Sociable; approaches to sniff and greet with a soft meow. Ideal for calm homes.', '/Images/gatos/Laka.png'),
(5, 'Fresia', 'Carey', 3, 1, 'Hembra', 'Activa en sesiones de juego y luego se relaja contigo en el sofá. Se lleva bien con gatos tranquilos.', 'Active during play sessions, then relaxes with you on the sofa. Gets along with calm cats.', '/Images/gatos/Fresia.png'),
(2, 'Yute', 'Blanco y pardo', 2, 1, 'Macho', 'Muy curioso: inspecciona mochilas y bolsillos. Le atraen los juguetes crujientes.', 'Very curious: inspects backpacks and pockets. Drawn to crinkly toys.', '/Images/gatos/Yute.png'),
(3, 'Hera', 'Blanco y pardo', 4, 0, 'Hembra', 'Dama tranquila que disfruta del silencio. Prefiere un rincón propio para dormir.', 'A calm lady who enjoys quiet. Prefers a private corner to sleep.', '/Images/gatos/Hera.png'),
(4, 'Cajú', 'Blanco y pardo', 3, 1, 'Macho', 'Le encanta mirar por la ventana y seguir pájaros con la vista. Muy ordenado con su arenero.', 'Loves birdwatching from the window. Very tidy with his litter box.', '/Images/gatos/Caju.png'),
(5, 'Okra', 'Blanco y pardo', 5, 1, 'Hembra', 'Sosegada y cariñosa a ratitos. Le gusta que la llamen por su nombre antes de acercarse.', 'Calm and affectionate in bursts. Likes being called by name before approaching.', '/Images/gatos/Okra.png'),
(6, 'Risco', 'Blanco y pardo', 1, 1, 'Macho', 'Cachorro con mucha energía controlada. Ideal para jugar dos o tres veces al día.', 'Kitten with well-managed energy. Ideal for two or three play sessions a day.', '/Images/gatos/Risco.png'),
(1, 'Zuma', 'Blanco y pardo', 6, 0, 'Hembra', 'Le encantan las camas blandas y los rascadores de cartón. Acepta caricias largas.', 'Loves soft beds and cardboard scratchers. Accepts long petting sessions.', '/Images/gatos/Zuma.png'),
(2, 'Río', 'Naranja y negro', 3, 1, 'Macho', 'Patrón atigrado precioso y carácter alegre. Pide juego con suaves toques de pata.', 'Beautiful tabby pattern and cheerful character. Asks for play with gentle paw taps.', '/Images/gatos/Rio.png'),
(3, 'Celia', 'Naranja y negro', 2, 0, 'Hembra', 'Dinámica y curiosa, explora y vuelve para pedir mimos. Le encantan las cañas con plumas.', 'Dynamic and curious; explores then returns for cuddles. Loves feather wands.', '/Images/gatos/Celia.png'),
(4, 'Gorrión', 'Naranja y negro', 5, 1, 'Macho', 'Confiado y simpático con visitas pacientes. Disfruta las rutinas y los premios blanditos.', 'Confident and friendly with patient visitors. Enjoys routines and soft treats.', '/Images/gatos/Gorrion.png'),
(5, 'Samba', 'Naranja y negro', 1, 1, 'Hembra', 'Cachorra vivaz que persigue todo lo que rueda. Se calma si la acunas en brazos.', 'Lively kitten who chases anything that rolls. Calms when cradled in your arms.', '/Images/gatos/Samba.png'),
(6, 'Bongo', 'Naranja y negro', 4, 1, 'Macho', 'Le gusta “conversar” con pequeños maullidos. Agradece juegos cortos y frecuentes.', 'He “talks” with small meows. Appreciates short, frequent play.', '/Images/gatos/Bongo.png'),
(1, 'Tamal', 'Naranja y negro', 6, 0, 'Macho', 'Sosegado y cariñoso. Busca la compañía sin ser invasivo y respeta los espacios.', 'Calm and affectionate. Seeks company without being intrusive and respects space.', '/Images/gatos/Tamal.png'),
(2, 'Trébol', 'Tricolor', 2, 1, 'Hembra', 'Activa y despierta; le gusta investigar cajones y bolsas. Luego duerme como un tronco.', 'Active and alert; likes to inspect drawers and bags. Then sleeps like a log.', '/Images/gatos/Trebol.png'),
(3, 'Musa', 'Tricolor', 4, 1, 'Hembra', 'Muy sociable y conversadora. Se adapta bien a rutinas con juego diario.', 'Very sociable and talkative. Adapts well to routines with daily play.', '/Images/gatos/Musa.png'),
(4, 'Vaina', 'Tricolor', 3, 0, 'Hembra', 'Sutil y observadora; disfruta mirar por la ventana. Agradece caricias suaves en la cabeza.', 'Subtle and observant; enjoys window watching. Appreciates gentle head pets.', '/Images/gatos/Vaina.png'),
(5, 'Rima', 'Tricolor', 5, 1, 'Hembra', 'Amorosa y paciente; perfecta para tardes tranquilas de sofá y manta.', 'Loving and patient; perfect for quiet blanket-on-the-sofa afternoons.', '/Images/gatos/Rima.png'),
(6, 'Ilda', 'Tricolor', 1, 1, 'Hembra', 'Pequeñita y curiosa; le gustan peluches blandos. Duerme pegadita a su humano.', 'Tiny and curious; likes soft plush toys. Sleeps snuggled up to her human.', '/Images/gatos/Ilda.png'),
(2, 'Saga', 'Tricolor', 6, 1, 'Hembra', 'De carácter equilibrado: juego moderado y largos descansos. Ideal para pisos luminosos.', 'Balanced temperament: moderate play and long rests. Ideal for bright apartments.', '/Images/gatos/Saga.png'),
(3, 'Lotus', 'Siames', 3, 1, 'Macho', 'Típico siamés conversador que responde a tu voz. Disfruta juegos de inteligencia sencillos.', 'A classic chatty Siamese who responds to your voice. Enjoys simple puzzle games.', '/Images/gatos/Lotus.png'),
(4, 'Shiva', 'Siames', 2, 0, 'Hembra', 'Lista y muy apegada; busca contacto visual y maúlla suave. Se adapta rápido.', 'Smart and attached; seeks eye contact and meows softly. Adapts quickly.', '/Images/gatos/Shiva.png'),
(5, 'Kasai', 'Siames', 4, 1, 'Macho', 'Elegante y curioso, pide juego con toques de pata. Agradece sesiones cortas y regulares.', 'Elegant and curious; asks for play with gentle paw taps. Appreciates short, regular sessions.', '/Images/gatos/Kasai.png'),
(6, 'Nara', 'Siames', 5, 1, 'Hembra', 'Muy comunicativa; hace pequeños trinos cuando te ve. Le encantan las ventanas soleadas.', 'Very communicative; chirps softly when she sees you. Loves sunny windows.', '/Images/gatos/Nara.png'),
(1, 'Zen', 'Siames', 6, 0, 'Macho', 'Templado y observador; perfecto para un hogar que valore la calma. Le gusta el cepillado suave.', 'Even-tempered and observant; perfect for a home that values calm. Likes gentle brushing.', '/Images/gatos/Zen.png'),
(5, 'Taiga', 'Siames', 3, 1, 'Hembra', 'Energia justa y mucho cariño. Alterna juego con largas siestas enrollada en una manta.', 'Just the right energy and lots of affection. Alternates play with long blanket-wrapped naps.', '/Images/gatos/Taiga.png');


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

CREATE TABLE Eventos (
    Id_Evento INT IDENTITY(1,1) PRIMARY KEY,
    Id_Protectora INT NOT NULL,
    Nombre_Evento VARCHAR(150) NOT NULL,
    Lugar VARCHAR(150) NOT NULL,
    Fecha_Evento DATE NOT NULL,
    Hora_Evento TIME NOT NULL,
    Descripcion_Evento VARCHAR(1000) NOT NULL,
    EnclaceMaps VARCHAR(5000),
    Foto_Evento VARCHAR(5000),
    FOREIGN KEY (Id_Protectora) REFERENCES Protectora(Id_Protectora)
);
