module internal Ehingeeinae.Ecs.Utils

module ResizeArray =

    open System
    open System.Collections.Generic
    open System.Reflection
    open FSharp.Quotations
    open FSharp.Quotations.Evaluator
    open System.Linq.Expressions
    open System.Reflection.Emit

    // ----
    // Reflection

    let cache_Reflection = Dictionary<Type, obj>()
    let getItems_Reflection (rarr: ResizeArray<'a>) : ArraySegment<'a> =
        let getItems =
            match cache_Reflection.TryGetValue(typeof<'a>) with
            | true, f -> f
            | false, _ ->
                let field = typeof<ResizeArray<'a>>.GetField("_items", BindingFlags.NonPublic ||| BindingFlags.Instance)
                let f = fun (rarrTarget: ResizeArray<'a>) -> field.GetValue(rarrTarget) :?> 'a[]
                cache_Reflection.[typeof<'a>] <- f
                box f
        let f: ResizeArray<'a> -> 'a[] = unbox getItems
        let _items: 'a[] = f rarr
        ArraySegment(_items, 0, rarr.Count)

    // ----
    // FSharp Expr

    let cache_FSharpExpr = Dictionary<Type, obj>()
    let getItems_FSharpExpr (rarr: ResizeArray<'a>) : ArraySegment<'a> =
        let getItems =
            match cache_FSharpExpr.TryGetValue(typeof<'a>) with
            | true, f -> f
            | false, _ ->
                let field = typeof<ResizeArray<'a>>.GetField("_items", BindingFlags.NonPublic ||| BindingFlags.Instance)
                let expr =
                    let rarrTargetVar = Var("rarrTarget", rarr.GetType())
                    Expr.Lambda(
                        rarrTargetVar,
                        Expr.FieldGet(Expr.Var(rarrTargetVar), field)
                    )
                let f = expr.CompileUntyped()
                cache_FSharpExpr.[typeof<'a>] <- f
                box f
        let f: ResizeArray<'a> -> 'a[] = unbox getItems
        let _items: 'a[] = f rarr
        ArraySegment(_items, 0, rarr.Count)

    // ----
    // Linq Expressions

    let private cache_LinqExpressions: Dictionary<Type, obj> = Dictionary()
    let getItems_LinqExpressions (rarr: ResizeArray<'a>) : ArraySegment<'a> =
        let getItems =
            match cache_LinqExpressions.TryGetValue(typeof<'a>) with
            | true, f -> f
            | false, _ ->
                let field = typeof<ResizeArray<'a>>.GetField("_items", BindingFlags.NonPublic ||| BindingFlags.Instance)
                let expression =
                    let parameter = Expression.Parameter(rarr.GetType(), "rarrTarget")
                    Expression.Lambda(
                        Expression.Field(parameter, field),
                        parameter
                    )
                let f = expression.Compile()
                cache_LinqExpressions.[typeof<'a>] <- f
                box f
        let f: Func<ResizeArray<'a>, 'a[]> = unbox getItems
        let _items: 'a[] = f.Invoke(rarr)
        ArraySegment(_items, 0, rarr.Count)

    // ----
    // DynamicMethod

    let private cache_DynamicMethod: Dictionary<Type, obj> = Dictionary()
    let getItems_DynamicMethod (rarr: ResizeArray<'a>) : ArraySegment<'a> =
        let getItems =
            match cache_DynamicMethod.TryGetValue(typeof<'a>) with
            | true, f -> f
            | false, _ ->
                let field = typeof<ResizeArray<'a>>.GetField("_items", BindingFlags.NonPublic ||| BindingFlags.Instance)

                let fieldGetter = DynamicMethod("FieldGetter", typeof<'a[]>, [| typeof<ResizeArray<'a>> |], restrictedSkipVisibility=true)
                let il = fieldGetter.GetILGenerator()
                il.Emit(OpCodes.Ldarg_0)
                il.Emit(OpCodes.Ldfld, field)
                il.Emit(OpCodes.Ret)

                let f = fieldGetter.CreateDelegate(typeof<Func<ResizeArray<'a>, 'a[]>>)

                cache_DynamicMethod.[typeof<'a>] <- f
                box f
        let f: Func<ResizeArray<'a>, 'a[]> = unbox getItems
        let _items: 'a[] = f.Invoke(rarr)
        ArraySegment(_items, 0, rarr.Count)

    // ----

    type Cache_GetItems_Reflection<'a> private () =
        static member val Instance =
            let field = typeof<ResizeArray<'a>>.GetField("_items", BindingFlags.NonPublic ||| BindingFlags.Instance)
            fun (rarrTarget: ResizeArray<'a>) -> field.GetValue(rarrTarget) :?> 'a[]

    let getItems_Reflection_StaticCache (rarr: ResizeArray<'a>) : ArraySegment<'a> =
        let f: ResizeArray<'a> -> 'a[] = Cache_GetItems_Reflection<'a>.Instance
        let _items: 'a[] = f rarr
        ArraySegment(_items, 0, rarr.Count)

    // ----
    let getItems rarr = getItems_Reflection rarr
