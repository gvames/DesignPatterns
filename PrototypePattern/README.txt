

		*** Prototype Pattern *** (Creational)
		
		Acest pattern permite crearea de noi instanțe ale unei clase fără a folosi constructori standard, 
		ci clonând o instanță existentă a acelei clase.
		
		Există două modalități principale de a implementa Prototype Pattern în .NET:

		1. Interfața ICloneable: Interfața ICloneable este o interfață built-in în .NET care permite clonarea 
		obiectelor. Pentru a folosi această interfață, clasa trebuie să implementeze metoda Clone(), 
		care returnează o copie a instanței curente a clasei. Cu toate acestea, trebuie să fiți conștienți că 
		această metodă de clonare poate duce la probleme, cum ar fi clonarea superficială sau adâncă, 
		și este recomandată folosirea cu precauție.
		2. Metoda de clonare personalizată: O altă opțiune este să creați o metodă personalizată de clonare 
		pentru clasa dvs., care să creeze o copie a obiectului curent, fie printr-o clonare superficială 
		(shallow clone), fie printr-o clonare adâncă (deep clone), în funcție de nevoile dvs. și de structura 
		obiectelor.
		
		Prototype Pattern este util în situațiile în care crearea unui obiect implică o cantitate mare de resurse
		sau de timp, iar clonarea unui obiect existent este mai eficientă. De asemenea, este util atunci când 
		structura obiectului este complexă și necesită o clonare personalizată pentru a evita problemele legate
		de referințe împărțite.

		Un exemplu comun de utilizare a Prototype Pattern este în implementarea de tipuri de date imutabile 
		sau de obiecte care sunt costisitoare de creat, cum ar fi obiectele dintr-o bază de date sau obiectele 
		care necesită inițializare complexă. Clonarea acestor obiecte existente poate fi mult mai eficientă 
		decât crearea lor de la zero.