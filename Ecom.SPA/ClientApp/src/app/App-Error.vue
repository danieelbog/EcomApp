<template>
    <header>
        <div class="message">
            <h2>An error occured during Application initialization</h2>
            <p>{{ error }}</p>
        </div>
    </header>

    <RouterView />
</template>

<script lang="ts">
    export default {
        props: {
            error: Error
        },
        setup(props: any) {
            console.log(props.title)
        }
    }
</script>


<style>
    body {
        font-family: sans-serif;
    }
</style>
