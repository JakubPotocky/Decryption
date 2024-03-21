using System.Reactive;
using System.Collections.ObjectModel; //we added this aswell /Generic
using ReactiveUI;
using System.Linq; //we added this

namespace Decryption.ViewModels;
public class MainWindowViewModel : ViewModelBase
{
    AtbashCipher AC = new();
    private string _atbashInput = string.Empty;
    private string _atbashOutput = string.Empty;
    public string AtbashInput
    {
        get => _atbashInput;
        set => this.RaiseAndSetIfChanged(ref _atbashInput, value);
    }
    public string AtbashOutput
    {
        get => _atbashOutput;
        set => this.RaiseAndSetIfChanged(ref _atbashOutput, value);
    }
    public void AtbashCode()
    {
        string change = AC.Decode(AtbashInput);
        AtbashOutput = change;
        if(change == "")
        {
            AtbashOutput = "ERROR";
        }
    }
    public void AtbashDecode()
    {
        AtbashOutput = AC.Encode(AtbashInput);
    }

    //======================================================================

    CeasarCipher CC = new();
    private string _ceasarInput = string.Empty;
    private string _ceasarOutput = "To decode message please put as first character number which will indicate the number of shifts in your decoding process.";
    public string CeasarInput
    {
        get => _ceasarInput;
        set => this.RaiseAndSetIfChanged(ref _ceasarInput, value);
    }
    public string CeasarOutput
    {
        get => _ceasarOutput;
        set => this.RaiseAndSetIfChanged(ref _ceasarOutput, value);
    }
    public void CeasarCode()
    {
        if(CeasarInput != null && CeasarInput != "")
        {   
            CeasarOutput = CC.Decode(CeasarInput);
        }
    }
    public void CeasarDecode()
    {
        //call func to pass string and get result
        CeasarOutput = CC.Encode(CeasarInput);
        CeasarInput = CeasarOutput;
    }

    //======================================================================
    private string _playfairInput = string.Empty;
    private string _playfairOutput = string.Empty;
    public string PlayfairInput
    {
        get => _playfairInput;
        set => this.RaiseAndSetIfChanged(ref _playfairInput, value);
    }
    public string PlayfairOutput
    {
        get => _playfairOutput;
        set => this.RaiseAndSetIfChanged(ref _playfairOutput, value);
    }
    public void PlayfairCode()
    {
        //call func to pass string and get result
        PlayfairOutput = "Coded message -> Playfair";
    }
    public void PlayfairDecode()
    {
        //call func to pass string and get result
        PlayfairOutput = "Decoded message  -> Playfair";
    }

     //======================================================================

}
