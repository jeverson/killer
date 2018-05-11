namespace Killer
{

  public class CrimeDetails {
    
    public CrimeDetails (int killer, int place, int weapon) {
      this.Killer = killer;
      this.Place = place;
      this.Weapon = weapon;
    }
    public int Killer { get; private set; }
    public int Place { get; private set; }
    public int Weapon { get; private set; }
  }
}