package Exerc_Cachorro;

public class Main_cachorro {

    public static void main(String[] args) {
        
        Cachorro c = new Cachorro();
        
        c.setNome("Spike");
        c.setRaca("Bulldog");
        c.getNome();
        c.getRaca();
        
        c.latir();
        
        System.out.println(c.getNome());
        System.out.println(c.getRaca());
        
        
    }
}