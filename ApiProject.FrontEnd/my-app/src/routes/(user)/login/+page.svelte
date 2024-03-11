<script lang="ts">
     /** @type {import('./$types').PageData} */
     import { enhance } from '$app/forms';
     import type { ActionData } from './$types';
     export let form: ActionData;
     import { fade } from 'svelte/transition';
    
     
     
</script>

<div class="login-form">
    <form method="POST" action="?/login" use:enhance>
        
        <label for="email">E-mail:</label>
        <input type="email" name="email" autocomplete="off"/>
        <label for="personalId">ЕГН:</label>
        <input type="text" name="personalId" autocomplete="off"/>
        <button type="submit">Влез</button>
        
        {#if form?.error}
            <div transition:fade={{ delay: 250, duration: 300 }} class="notice-error fadein ">
            {form.error}
            </div>
        {/if}
        {#await form}
        <p>Влизане...</p>
        {/await}

        <a href="/register">Нямате акаунт?Кликнете тук,за да се регистрирате</a>
    </form>
</div>

<style>

    

    .notice-error{
        padding: 10px;
        margin-top: 10px;
        background-color: darkred;
        color: white;
    }
    .login-form {
        display: flex;
        justify-content: center;
        align-items: center;
        height: 100vh;
        padding: 20px;
        box-sizing: border-box;
        background-color: white;
    }

    form {
        width: 100%;
        max-width: 400px;
        padding: 40px;
        background-color: white;
        border-radius: 10px;
        box-shadow: 0px 0px 10px 0px rgba(0,0,0,0.1);
    }

    label {
        font-size: 18px;
        margin-bottom: 10px;
        display: block;
        color: black;
        font-family: Arial, Helvetica, sans-serif;
    }

    input {
        width: 100%;
        padding: 10px;
        font-size: 16px;
        border-radius: 5px;
        border: 1px solid #8899a6;
        margin-bottom: 20px;
        background-color: #253341;
        color: #fff;
    }

    button {
        width: 100%;
        padding: 10px;
        border: none;
        border-radius: 5px;
        background-color: #004080;
        color: #fff;
        font-size: 18px;
        cursor: pointer;
    }

    a {
        display: block;
        text-align: center;
        margin-top: 20px;
        color: #1da1f2;
        text-decoration: none;
    }

    @media (max-width: 600px) {
        form {
            padding: 20px;
        }
    }
</style>
