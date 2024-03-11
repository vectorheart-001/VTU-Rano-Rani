<script lang="ts">
    import { enhance } from '$app/forms';
    import type { LayoutData } from './$types';
    export let data: LayoutData;
    
</script>

<div class = "navbar-main">
    <h2><a href = "/">ВТУ Акция: "Рано рани"</a></h2>
    <div class = "registration-div">
        {#if data.user}
            <h3><a href="/profile">Профил</a></h3>
            <form class="logout" action="/logout" method="POST" use:enhance>
                <h3><button type="submit">Излез</button></h3>
            </form>
        {:else}
        <h3><a href="/login"> Вход</a></h3>
        <h3><a href ="/register"> Регистрация</a></h3>
        {/if}
    </div>
</div>
<slot />

<style>
    .navbar-main{
        box-sizing: border-box;
        padding-left: 10px;
        display: flex;
        flex-direction: row;
        background-color: #004080;
        color: aliceblue;
        justify-content: space-between;
        align-items: baseline;
        width: 100%;
    }
    .registration-div{
        display: flex;
        gap:30px;
        flex-direction: row;
        justify-content: center;
        width: 300px;
    }
    h3, button{
        font-family: Arial, Helvetica, sans-serif;
    }
    a, button{
        text-decoration: none;
        color: aliceblue;
    }
	h2
	{
		font-family: Arial, Helvetica, sans-serif;
	}
    button{
        border: none;
        background: none;
        font-size:18px;
        font-weight: bold;
        
    }
    button:hover{
        cursor: pointer;
    }
</style>