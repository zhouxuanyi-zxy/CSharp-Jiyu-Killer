// Jiyu-Killer C Sharp Edition
// Version 1.01
// License: MIT License

using System.Text;
using CliWrap;

if (is_file_exist()){
    await kill("taskkill");
    await kill("pskill");
    await kill("ntsd");
}

static bool is_file_exist(){
    string check_file = "pskill.exe";
    if (File.Exists(check_file)){
        check_file = "ntsd.exe";
        if (File.Exists(check_file)){
            Console.WriteLine("文件检测完毕!");
            return true;
        }
        else{
            Console.WriteLine("缺少ntsd.exe!");
            return false;
        }
    }
    else{
        Console.WriteLine("缺少pskill.exe");
        return false;
    }
}

async static Task kill(string use_program){
    var program_output = new StringBuilder();
    try{
        if (use_program == "pskill"){
            var pksill = await Cli.Wrap("pskill.exe")
                .WithArguments(["-nobanner","-t","StudentMain.exe"])
                .WithStandardOutputPipe(PipeTarget.ToStringBuilder(program_output))
                .ExecuteAsync();
                
            // Console.WriteLine(program_output.ToString());
        }
        else if (use_program == "ntsd"){
            var pksill = await Cli.Wrap("ntsd.exe")
                .WithArguments(["-c","q","-pn","StudentMain.exe"])
                .WithStandardOutputPipe(PipeTarget.ToStringBuilder(program_output))
                .ExecuteAsync();
        }
        else if (use_program == "taskkill"){
            var pksill = await Cli.Wrap("taskkill.exe")
                .WithArguments(["/F","/T","/IM","StudentMain.exe"])
                .WithStandardOutputPipe(PipeTarget.ToStringBuilder(program_output))
                .ExecuteAsync();
        }
    }
    catch (CliWrap.Exceptions.CommandExecutionException er){
        Console.WriteLine("Task Not found.");
        Console.WriteLine(er);
    }
    // Console.WriteLine(pskill_o.ToString());
}