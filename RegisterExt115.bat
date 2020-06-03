@ECHO OFF
REM ============================================================================
@ECHO Move to the drive / folder where the batch file exists
CHDIR /D %~dp0
IF "%ProgramW6432%" == "" GOTO ADMINCHECK
IF "%ProgramW6432%" == "%ProgramFiles%" GOTO ADMINCHECK
REM ============================================================================
@ECHO
@ECHO Reregistration is not supported in 32-bit mode on 64-bit OS.
@ECHO Please execute in 64-bit mode.
@ECHO
GOTO EOF

:ADMINCHECK
@ECHO Check if running with administrator privileges
openfiles > NUL 2>&1
IF NOT %ERRORLEVEL% EQU 0 (
    @ECHO Because there is no administrator privileges, grant privileges with start-process -verb runas
    REM powershell start-process Batch file to start -ArgumentList "argument1","argument2" -verb runas
    powershell start-process %0 -verb runas
    GOTO EOF
)

REM ============================================================================
REM 
IF "%ProgramW6432%" == "" GOTO X86
IF "%ProgramW6432%" == "%ProgramFiles%" GOTO X64
GOTO EOF

REM ============================================================================
REM Windows 32bit version
:X86
REM ----------------------------------------------------------------------------
@ECHO Registration of OpenPOS.Extension file
CHDIR "build"
FOR %%F IN (OpenPOS*.dll) DO .\gacutil /i %%F /f /silent
FOR %%F IN (OpenPOS*.dll) DO "%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\RegAsm.exe" %%F /silent

GOTO EOF

REM ============================================================================
REM Windows 64bit version
:X64
REM ----------------------------------------------------------------------------
@ECHO Registration of OpenPOS.Extension file
CHDIR "build"
FOR %%F IN (OpenPOS*.dll) DO .\gacutil /i %%F /f /silent
FOR %%F IN (OpenPOS*.dll) DO "%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\RegAsm.exe" %%F /silent
FOR %%F IN (OpenPOS*.dll) DO "%SystemRoot%\Microsoft.NET\Framework64\v4.0.30319\RegAsm.exe" %%F /silent

:EOF
CHDIR /D %~dp0
