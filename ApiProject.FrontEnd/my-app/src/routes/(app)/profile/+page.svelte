<script>
    import { enhance } from '$app/forms';
    import { goto, invalidate, invalidateAll } from '$app/navigation';
    import { onMount } from 'svelte';
    
    $:pdfValue = ""
    
    /** @type {import('./$types').PageData} */
    export let data;
    
    console.log(data.user?.request_status)
    onMount(() => {invalidateAll()})
    
</script>



<div class="profile-container">
    
    <div class="left-side">
    <h2>Профил</h2>
    <p>Име: {data.user?.name}</p>
    <p>ЕГН: {data.user?.personalId}</p>
    <p>E-mail: {data.user?.email}</p>
    <p>Телефон: {data.user?.phone}</p>
    </div>
    
    <div class = "right-side">
    <h2>Специалност</h2>
    {#if data.major.id != "000"}
    
    <p>{data.major.name + "," + data.major.type+ ","  + data.major.paymentType}</p>
        <form method="post" enctype="multipart/form-data" use:enhance>
            {#if data.user?.request_status != "Платена"}
                <label for="pdf">Прикачете платежно (PDF формат):</label>
                <input bind:value={pdfValue}  accept="application/pdf"  name="pdf" type="file"  required  />
                
                {#if pdfValue != ""}
                    <p style="color: red;">ВНИМАНИЕ!След заплащaне желаната специалност не може да бъде променена!</p>
                    <button type = "submit">Изпращане</button>
                {/if}
            {:else}
                <p></p>            
            {/if}
            
        </form>
    <p>Статут на заявката: {data.user?.request_status}</p>
    
    {:else}
    <p>Вие все още не сте избрали специалност.</p>
    {/if}
    </div>
</div>

<style>
    .left-side{
        border-right: solid;
        padding-right: 20px;
        width: 25%;
    }
    .profile-container {
       
        display: flex;
        gap: 150px;
        flex-direction: row;
        width: 80%;
        margin: auto;
        padding: 20px;
        box-shadow: 0px 0px 10px rgba(0,0,0,0.1);
    }
    p {
        color: #333;
        line-height: 1.6;
    }
    form {
        margin-top: 20px;
    }
    button {
        background-color: #004080;
        color: white;
        padding: 15px 32px;
        text-align: center;
        text-decoration: none;
        display: inline-block;
        font-size: 16px;
        margin: 4px 2px;
        cursor: pointer;
        border: none;
    }
    p{
        font-family: Arial, sans-serif;
        font-size: 16px;
    }
    h2{
        font-family: Arial, sans-serif;
    }
</style>
