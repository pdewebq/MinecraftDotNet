module MinecraftDotNet.Core.Input

type Key =
    | Unknown = 0s
    | LShift = 1s
    | ShiftLeft = 1s
    | RShift = 2s
    | ShiftRight = 2s
    | ControlLeft = 3s
    | LControl = 3s
    | ControlRight = 4s
    | RControl = 4s
    | AltLeft = 5s
    | LAlt = 5s
    | AltRight = 6s
    | RAlt = 6s
    | LWin = 7s
    | WinLeft = 7s
    | RWin = 8s
    | WinRight = 8s
    | Menu = 9s
    | F1 = 10s // 0x0000000A
    | F2 = 11s // 0x0000000B
    | F3 = 12s // 0x0000000C
    | F4 = 13s // 0x0000000D
    | F5 = 14s // 0x0000000E
    | F6 = 15s // 0x0000000F
    | F7 = 16s // 0x00000010
    | F8 = 17s // 0x00000011
    | F9 = 18s // 0x00000012
    | F10 = 19s // 0x00000013
    | F11 = 20s // 0x00000014
    | F12 = 21s // 0x00000015
    | F13 = 22s // 0x00000016
    | F14 = 23s // 0x00000017
    | F15 = 24s // 0x00000018
    | F16 = 25s // 0x00000019
    | F17 = 26s // 0x0000001A
    | F18 = 27s // 0x0000001B
    | F19 = 28s // 0x0000001C
    | F20 = 29s // 0x0000001D
    | F21 = 30s // 0x0000001E
    | F22 = 31s // 0x0000001F
    | F23 = 32s // 0x00000020
    | F24 = 33s // 0x00000021
    | F25 = 34s // 0x00000022
    | F26 = 35s // 0x00000023
    | F27 = 36s // 0x00000024
    | F28 = 37s // 0x00000025
    | F29 = 38s // 0x00000026
    | F30 = 39s // 0x00000027
    | F31 = 40s // 0x00000028
    | F32 = 41s // 0x00000029
    | F33 = 42s // 0x0000002A
    | F34 = 43s // 0x0000002B
    | F35 = 44s // 0x0000002C
    | Up = 45s // 0x0000002D
    | Down = 46s // 0x0000002E
    | Left = 47s // 0x0000002F
    | Right = 48s // 0x00000030
    | Enter = 49s // 0x00000031
    | Escape = 50s // 0x00000032
    | Space = 51s // 0x00000033
    | Tab = 52s // 0x00000034
    | Back = 53s // 0x00000035
    | BackSpace = 53s // 0x00000035
    | Insert = 54s // 0x00000036
    | Delete = 55s // 0x00000037
    | PageUp = 56s // 0x00000038
    | PageDown = 57s // 0x00000039
    | Home = 58s // 0x0000003A
    | End = 59s // 0x0000003B
    | CapsLock = 60s // 0x0000003C
    | ScrollLock = 61s // 0x0000003D
    | PrintScreen = 62s // 0x0000003E
    | Pause = 63s // 0x0000003F
    | NumLock = 64s // 0x00000040
    | Clear = 65s // 0x00000041
    | Sleep = 66s // 0x00000042
    | Keypad0 = 67s // 0x00000043
    | Keypad1 = 68s // 0x00000044
    | Keypad2 = 69s // 0x00000045
    | Keypad3 = 70s // 0x00000046
    | Keypad4 = 71s // 0x00000047
    | Keypad5 = 72s // 0x00000048
    | Keypad6 = 73s // 0x00000049
    | Keypad7 = 74s // 0x0000004A
    | Keypad8 = 75s // 0x0000004B
    | Keypad9 = 76s // 0x0000004C
    | KeypadDivide = 77s // 0x0000004D
    | KeypadMultiply = 78s // 0x0000004E
    | KeypadMinus = 79s // 0x0000004F
    | KeypadSubtract = 79s // 0x0000004F
    | KeypadAdd = 80s // 0x00000050
    | KeypadPlus = 80s // 0x00000050
    | KeypadDecimal = 81s // 0x00000051
    | KeypadPeriod = 81s // 0x00000051
    | KeypadEnter = 82s // 0x00000052
    | A = 83s // 0x00000053
    | B = 84s // 0x00000054
    | C = 85s // 0x00000055
    | D = 86s // 0x00000056
    | E = 87s // 0x00000057
    | F = 88s // 0x00000058
    | G = 89s // 0x00000059
    | H = 90s // 0x0000005A
    | I = 91s // 0x0000005B
    | J = 92s // 0x0000005C
    | K = 93s // 0x0000005D
    | L = 94s // 0x0000005E
    | M = 95s // 0x0000005F
    | N = 96s // 0x00000060
    | O = 97s // 0x00000061
    | P = 98s // 0x00000062
    | Q = 99s // 0x00000063
    | R = 100s // 0x00000064
    | S = 101s // 0x00000065
    | T = 102s // 0x00000066
    | U = 103s // 0x00000067
    | V = 104s // 0x00000068
    | W = 105s // 0x00000069
    | X = 106s // 0x0000006A
    | Y = 107s // 0x0000006B
    | Z = 108s // 0x0000006C
    | Number0 = 109s // 0x0000006D
    | Number1 = 110s // 0x0000006E
    | Number2 = 111s // 0x0000006F
    | Number3 = 112s // 0x00000070
    | Number4 = 113s // 0x00000071
    | Number5 = 114s // 0x00000072
    | Number6 = 115s // 0x00000073
    | Number7 = 116s // 0x00000074
    | Number8 = 117s // 0x00000075
    | Number9 = 118s // 0x00000076
    | Grave = 119s // 0x00000077
    | Tilde = 119s // 0x00000077
    | Minus = 120s // 0x00000078
    | Plus = 121s // 0x00000079
    | BracketLeft = 122s // 0x0000007A
    | LBracket = 122s // 0x0000007A
    | BracketRight = 123s // 0x0000007B
    | RBracket = 123s // 0x0000007B
    | Semicolon = 124s // 0x0000007C
    | Quote = 125s // 0x0000007D
    | Comma = 126s // 0x0000007E
    | Period = 127s // 0x0000007F
    | Slash = 128s // 0x00000080
    | BackSlash = 129s // 0x00000081
    | NonUSBackSlash = 130s // 0x00000082
    | LastKey = 131s // 0x00000083

module Key =
    let private lastKey =
        System.Enum.GetValues(typeof<Key>)
        |> Seq.cast<Key>
        |> Seq.sort
        |> Seq.last
    
    let ofShort (code: int16) : Key option =
        if code >= 0s && code < (LanguagePrimitives.EnumToValue Key.LastKey)
        then Some (LanguagePrimitives.EnumOfValue code)
        else None
    
    let ofInt = int16 >> ofShort

//type PressKey =
//    | Down of Key
//    | Up of Key
//    | Hold of Key

type Keyboard = Keyboard of Set<Key>

module Keyboard =
    let empty = Keyboard Set.empty
    let isPressed key (Keyboard kb) = Set.contains key kb
    let press key (Keyboard kb) = Set.add key kb |> Keyboard
    