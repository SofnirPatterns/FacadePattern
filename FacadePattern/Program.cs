using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            HomeCinemaFacade homeCinemaFacade = new HomeCinemaFacade(new Amplifier(), new DvdPlayer(), 
                new Projector(), new Light(), new Screen(), new PopcornMachine());

            homeCinemaFacade.StartWatchingFilm("Paradaise Lost");            
            homeCinemaFacade.EndWatchingFilm();
            
            Console.ReadKey();
        }
    }

    public class Amplifier
    {
        public void On() { Console.WriteLine("Turn on amplifier"); }
        public void Off() { Console.WriteLine("Turn off amplifier"); }
        public void SetSurroundSound() { Console.WriteLine("Set surround sound"); }
        public void SetSoundLevel(int value) { Console.WriteLine("Set sound level as {0}", value); }        
    }
    public class DvdPlayer
    {
        public void On() { Console.WriteLine("Turn on dvd player"); }
        public void Off() { Console.WriteLine("Turn off dvd player"); }
        public void Play(string filmName) { Console.WriteLine("Play film {0}", filmName); }
        public void Stop() { Console.WriteLine("Stop dvd player"); }        
    }
    public class Projector
    {
        public void On() { Console.WriteLine("Turn on projector"); }
        public void Off() { Console.WriteLine("Turn off projector"); }
        public void SetWidescreen() { Console.WriteLine("Set widescreen mode"); }        
    }
    public class Light
    {
        public void On() { Console.WriteLine("Turn on light"); }
        public void Dim(int value) { Console.WriteLine("Set light level as {0}", value); }        
    }
    public class Screen {
        public void Up() { Console.WriteLine("Move up screen"); }
        public void Down() { Console.WriteLine("Move down screen"); }        
    }
    public class PopcornMachine
    {
        public void On() { Console.WriteLine("Turn on popcorn machine"); }
        public void Off() { Console.WriteLine("Turn off popcorn machine"); }        
        public void Start() { Console.WriteLine("Prepare popcorn"); }        
    }

    public class HomeCinemaFacade
    {
        Amplifier Amplifier;
        DvdPlayer DvdPlayer;
        Projector Projector;
        Light Light;
        Screen Screen;
        PopcornMachine PopcornMachine;
        
        public HomeCinemaFacade(Amplifier amplifier, DvdPlayer dvdPlayer, Projector projector, 
            Light light, Screen screen, PopcornMachine popcornMachine)
        {
            this.Amplifier = amplifier;
            this.DvdPlayer = dvdPlayer;
            this.Projector = projector;
            this.Light = light;
            this.Screen = screen;
            this.PopcornMachine = popcornMachine;
        }

        public void StartWatchingFilm(String film)
        {
            Console.WriteLine("Be ready for watching film...");
            PopcornMachine.On();
            PopcornMachine.Start();
            Light.Dim(10);
            Screen.Down();
            Projector.On();
            Projector.SetWidescreen();
            Amplifier.On();            
            Amplifier.SetSurroundSound();
            Amplifier.SetSoundLevel(5);
            DvdPlayer.On();
            DvdPlayer.Play(film);
        }

        public void EndWatchingFilm()
        {
            Console.WriteLine("\nEnd film, turning off film...");
            PopcornMachine.Off();
            Light.On();
            Screen.Up();
            Projector.Off();
            Amplifier.Off();
            DvdPlayer.Stop();
            DvdPlayer.Off();
        }
    }
}
