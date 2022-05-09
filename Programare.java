import java.io.Serializable;

public class Programare implements Comparable<Programare>, Serializable {
    public String disciplina;
    public int zi;
    public int interval;
    public Tip tip;
    public String formatia;

    public Programare() {
        this.disciplina = "N/A";
        this.zi = 0;
        this.interval = 0;
        this.tip = Tip.UNKNOWN;
        this.formatia = formatia;
    }

    public Programare(String disciplina, int zi, int interval, Tip tip, String formatia) {
        this.disciplina = disciplina;
        this.zi = zi;
        this.interval = interval;
        this.tip = tip;
        this.formatia = "N/A";
    }

    @Override
    public String toString() {
        return "Programare{" +
                "disciplina='" + disciplina + '\'' +
                ", zi=" + zi +
                ", interval=" + interval +
                ", tip=" + tip +
                ", formatia='" + formatia + '\'' +
                '}';
    }

    @Override
    public int compareTo(Programare o) {
        int result=0;
        if(this.zi > o.zi)
        {
            result = 1;
        }
        else if(this.zi<o.zi)
        {
            result= -1;
        }
        else if(this.zi==o.zi){
            if(this.interval>o.interval){
                result= 1;
            }
            else if(this.interval<o.interval)
            {
                result= -1;
            }
        }
        return result;
    }
}
