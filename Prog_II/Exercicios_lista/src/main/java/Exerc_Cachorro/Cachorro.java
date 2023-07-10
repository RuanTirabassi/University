package Exerc_Cachorro;

public class Cachorro {
    
    private String raca;
    private String nome;
    
    public Cachorro(){
        raca = "";
        nome = "";
    }
    
    public Cachorro(String nome){
        this.nome = nome;
        this.raca = "indeterminado";
    }
    
    public Cachorro(String nome, String raca){
        this.nome = nome;
        this.raca = raca;
    }
    
    public void setNome(String nome){
        this.nome = nome;
    }
    
    public void setRaca(String raca){
        this.raca = raca;
    }
    
    public String getNome(){
        return nome;
    }
    
    public String getRaca(){
        return raca;
    }
    
    public void latir(){
        System.out.println("auau");
    }
    
    public void latirRepetido(int x){
        
        if(x < 0){
            System.out.println("bugou");
        }
        else if(x > 100){
            System.out.println("parâmetro invalido");
        }
        else{
            for(int y = 0; y < x; y++){
                System.out.println("auau");
            }
        }
    }
          
}
