import java.io.*;
import java.util.*;
import java.util.function.Predicate;
import java.util.stream.Collectors;

public class Main {

    public Main() {
    }

    List<Programare> lista = new ArrayList<>();

    public void citire(String numeFisier) throws Exception {
        try (BufferedReader in = new BufferedReader(new FileReader(numeFisier))) {
            lista.clear();
            String linie;
            while ((linie = in.readLine()) != null) {
                Programare programare = new Programare();
                String[] t = linie.split(",");
                programare.disciplina = t[0];
                programare.zi= Integer.parseInt(t[1].trim());
                programare.interval= Integer.parseInt(t[2].trim());
                if(t[3].equals("CURS"))
                    programare.tip=Tip.CURS;
                else if(t[3].equals("SEMINAR"))
                    programare.tip=Tip.SEMINAR;
                else
                    programare.tip=Tip.UNKNOWN;
                programare.formatia=t[4];
                lista.add(programare);
            }
        }
    }

    public void print(String mesaj){
        System.out.println(mesaj);
        for (Programare programare:lista){
            System.out.println(programare);
        }
    }
    public void printareOrdonata(String mesaj){
        System.out.println(mesaj);
        List<Programare> listaOrdonata = lista.stream().sorted().collect(Collectors.toList());
        for (Programare programare:listaOrdonata){
            System.out.println(programare);
        }
    }
    public void afisareNrTotalCursuriSeminarii(List<Programare> lista)
    {
        int nrCursuri = 0;
        int nrSeminarii = 0;
        for(Programare p:lista){
            if(p.tip == Tip.CURS)
                nrCursuri++;
            if(p.tip == Tip.SEMINAR)
                nrSeminarii++;
        }
        System.out.println("Numar cursuri: " + nrCursuri);
        System.out.println("Numar seminarii: " + nrSeminarii);
    }

    public void salvare(String numeFisier) throws Exception {
        ObjectOutputStream out = new ObjectOutputStream(new FileOutputStream(numeFisier));

        try {
            Iterator var3 = lista.iterator();

            while(var3.hasNext()) {
                Programare p= (Programare) var3.next();
                out.writeObject(p);
            }
        } catch (Throwable var6) {
            try {
                out.close();
            } catch (Throwable var5) {
                var6.addSuppressed(var5);
            }

            throw var6;
        }

        out.close();
    }

    public void restaurare(String numeFisier) throws Exception {
        FileInputStream in1 = new FileInputStream(numeFisier);

        try {
            ObjectInputStream in = new ObjectInputStream(in1);

            try {
                this.lista.clear();

                while(in1.available() != 0) {
                    lista.add((Programare) in.readObject());
                }
            } catch (Throwable var8) {
                try {
                    in.close();
                } catch (Throwable var7) {
                    var8.addSuppressed(var7);
                }

                throw var8;
            }

            in.close();
        } catch (Throwable var9) {
            try {
                in1.close();
            } catch (Throwable var6) {
                var9.addSuppressed(var6);
            }

            throw var9;
        }

        in1.close();
    }
    public static void main(String[] args) throws Exception {
   try{
       Programare p1 = new Programare("matematica",2,3,Tip.CURS,"1058E");
       Programare p2 = new Programare("romana",2,2,Tip.CURS,"1059E");
       System.out.println(p1);
       System.out.println(p2);
       Main app = new Main();
       app.citire("orar.csv");
       app.print("Lista de studenti:");
       app.afisareNrTotalCursuriSeminarii(app.lista);
       app.salvare("programare.dat");
       app.restaurare("programare.dat");
       app.printareOrdonata("Lista restaurata:");

   }catch (Exception ex){
       System.err.println(ex);
   }



    }
}
